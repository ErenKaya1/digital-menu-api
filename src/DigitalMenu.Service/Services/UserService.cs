using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalMenu.Core.Cache;
using DigitalMenu.Core.Constants;
using DigitalMenu.Core.Enum;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Core.RabbitMQ;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using DigitalMenu.Service.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DigitalMenu.Service.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHasher _hasher;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEncryption _encryption;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IOptions<MailSettings> _mailSettings;
        private readonly IImageService _imageService;
        private readonly IRedisCacheService _redisCacheService;

        public UserService(IUnitOfWork unitOfWork,
                           IHasher hasher,
                           IMapper mapper,
                           ITokenService tokenService,
                           IEncryption encryption,
                           IRabbitMQService rabbitMQService,
                           IOptions<MailSettings> mailSettings,
                           IImageService imageService,
                           IRedisCacheService redisCacheService)
        {
            _unitOfWork = unitOfWork;
            _hasher = hasher;
            _mapper = mapper;
            _tokenService = tokenService;
            _encryption = encryption;
            _rabbitMQService = rabbitMQService;
            _mailSettings = mailSettings;
            _imageService = imageService;
            _redisCacheService = redisCacheService;
        }

        public async Task<ServiceResponse<UserDTO>> InsertUserAsync(RegisterModel model, string ipAddress)
        {
            // check if username and email are receivable
            if (await _unitOfWork.UserRepository.Find(x => x.UserName == model.UserName).AnyAsync())
                return new ServiceResponse<UserDTO>(false, "register failed", errorCode: ErrorCodes.DuplicatedUsername);
            else if (await _unitOfWork.UserRepository.Find(x => x.EmailAddress == _encryption.EncryptText(model.EmailAddress)).AnyAsync())
                return new ServiceResponse<UserDTO>(false, "register failed", errorCode: ErrorCodes.DuplicatedEmailAddress);

            var entity = _mapper.Map<DMUser>(model);
            entity.Id = Guid.NewGuid();
            entity.PasswordHash = _hasher.CreateHash(model.Password);

            // add role to user and save
            entity.Role = await _unitOfWork.RoleRepository.FindOneAsync(x => x.RoleName.ToLower() == "customer");
            _unitOfWork.UserRepository.Add(entity, true);

            // start trial version and save
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                IsTrialMode = true,
                IsSubscriptionReminderMailSent = false,
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddDays(14),
                IsSuspended = false,
                IsCurrent = true,
                UserId = entity.Id,
            };

            _unitOfWork.SubscriptionRepository.Add(subscription);

            // generate empty menu
            var menu = new Menu
            {
                Id = Guid.NewGuid(),
                UserId = entity.Id,
                BackgroundColor = DefaultMenuTheme.BackgroundColor,
                TextColor = DefaultMenuTheme.TextColor,
                PriceColor = DefaultMenuTheme.PriceColor,
                CategoryDescriptionColor = DefaultMenuTheme.CategoryDescriptionColor,
                SelectedCategoryBorderColor = DefaultMenuTheme.SelectedCategoryBorderColor,
                ProductBackgroundColor = DefaultMenuTheme.ProductBackgroundColor,
                LanguageCurrencyBackgroundColor = DefaultMenuTheme.LanguageCurrencyBackgroundColor,
                LanguageCurrencyTextColor = DefaultMenuTheme.LanguageCurrencyTextColor,
                LinkColor = DefaultMenuTheme.LinkColor,
            };

            _unitOfWork.MenuRepository.Add(menu);

            // generate jwt and refresh token
            var jwtToken = _tokenService.GenerateJwtToken(entity);
            var refreshToken = _tokenService.GenerateRefreshToken(ipAddress);
            refreshToken.UserId = entity.Id;
            _unitOfWork.RefreshTokenRepository.Add(refreshToken);

            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<UserDTO>(entity);
            data.AccessToken = jwtToken;
            data.RefreshToken = refreshToken.Token;
            data.EmailAddress = _encryption.DecryptText(data.EmailAddress);
            data.PhoneNumber = _encryption.DecryptText(data.PhoneNumber);

            return new ServiceResponse<UserDTO>(true)
            {
                Message = "registered successfully",
                Data = data
            };
        }

        public async Task<ServiceResponse<UserDTO>> AuthenticateAsync(LoginModel model, string ipAddress)
        {
            // check if username and email are correct
            var user = await _unitOfWork.UserRepository.Find(x => x.UserName == model.UserName && x.PasswordHash == _hasher.CreateHash(model.Password)).Include(x => x.Role).FirstOrDefaultAsync();
            if (user == null) return new ServiceResponse<UserDTO>(false, "authentication failed", errorCode: ErrorCodes.IncorrectLogin);

            // if correct, generate jwt and refresh token
            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(ipAddress);

            // revoke old refresh tokens
            await _tokenService.RevokeRefreshTokensAsync(user.Id, refreshToken.Token, ipAddress);

            // add new refresh token to db
            refreshToken.UserId = user.Id;
            _unitOfWork.RefreshTokenRepository.Add(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<UserDTO>(user);
            data.EmailAddress = _encryption.DecryptText(data.EmailAddress);
            data.PhoneNumber = _encryption.DecryptText(data.PhoneNumber);
            data.AccessToken = jwtToken;
            data.RefreshToken = refreshToken.Token;

            return new ServiceResponse<UserDTO>(true) { Data = data };
        }

        public async Task<ServiceResponse<UserDTO>> RefreshTokenAsync(string token, string ipAddress)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.RefreshToken.Any(x => x.Token == token)).Include(x => x.Role).FirstOrDefaultAsync();
            if (user == null) return new ServiceResponse<UserDTO>(false, "no user found with this token");
            var refreshToken = await _unitOfWork.RefreshTokenRepository.FindOneAsync(x => x.UserId == user.Id && x.Token == token && x.CreatedByIp == ipAddress);
            if (refreshToken == null) return new ServiceResponse<UserDTO>(false, "token not found");
            if (!refreshToken.IsActive) return new ServiceResponse<UserDTO>(false, "the token is not active");

            // replace old refresh token with a new one and save
            var newRefreshToken = _tokenService.GenerateRefreshToken(ipAddress);
            newRefreshToken.UserId = user.Id;

            refreshToken.RevokedAt = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;

            _unitOfWork.RefreshTokenRepository.Update(refreshToken);
            _unitOfWork.RefreshTokenRepository.Add(newRefreshToken);

            await _unitOfWork.SaveChangesAsync();

            // generate new jwt token
            var jwtToken = _tokenService.GenerateJwtToken(user);

            var data = _mapper.Map<UserDTO>(user);
            data.EmailAddress = _encryption.DecryptText(data.EmailAddress);
            data.PhoneNumber = _encryption.DecryptText(data.PhoneNumber);
            data.AccessToken = jwtToken;
            data.RefreshToken = newRefreshToken.Token;

            return new ServiceResponse<UserDTO>(true) { Data = data };
        }

        public async Task<ServiceResponse<Guid>> GetUserIdByEmailAsync(string emailAddress)
        {
            var user = await _unitOfWork.UserRepository.FindOneAsync(x => x.EmailAddress == _encryption.EncryptText(emailAddress));
            if (user == null) return new ServiceResponse<Guid>(false, "no user found with this email");
            return new ServiceResponse<Guid>(true) { Data = user.Id };
        }

        public async Task<ServiceResponse<Guid>> SendResetPasswordMailAsync(string emailAddress)
        {
            var userResponse = await GetUserIdByEmailAsync(emailAddress);
            if (!userResponse.Success) return new ServiceResponse<Guid>(false, userResponse.Message, userResponse.InternalMessage);
            var refreshPasswordTokenResponse = await _tokenService.GenerateResetPasswordTokenAsync(userResponse.Data);
            if (!refreshPasswordTokenResponse.Success) return new ServiceResponse<Guid>(false, refreshPasswordTokenResponse.Message, refreshPasswordTokenResponse.InternalMessage);
            var mailContent = $"<p>Parolanizi sifirlamak icin <a href='{CustomEnvironment.ClientAppUrl}/reset-password/{userResponse.Data}/{refreshPasswordTokenResponse.Data.Token}'>tiklayiniz</a>.</p>" +
                               "<p>Bu link 15 dakika sonra gecersiz olacaktir.</p>";

            var mail = new MailDTO
            {
                Subject = "Parola Sifirlama",
                From = _mailSettings.Value.Username,
                Content = mailContent,
                To = new List<string> { emailAddress },
            };

            var response = _rabbitMQService.Post(MessageQueueNames.EMAIL, mail);
            if (response)
                return new ServiceResponse<Guid>(true, "reset password mail was sent");
            else
                return new ServiceResponse<Guid>(false, "rabbit mq error");
        }

        public async Task<ServiceResponse<UserDTO>> ResetPasswordAsync(ResetPasswordModel model)
        {
            var tokenEntity = await _unitOfWork.ResetPasswordTokenRepository.FindOneAsync(x => x.UserId == model.UserId && x.TokenHash == _hasher.CreateHash(model.Token));
            if (tokenEntity == null) return new ServiceResponse<UserDTO>(false, "invalid token", errorCode: ErrorCodes.InvalidResetPasswordToken);
            if (tokenEntity.IsExpired) return new ServiceResponse<UserDTO>(false, "token was expired", errorCode: ErrorCodes.ExpiredResetPasswordToken);
            var user = await _unitOfWork.UserRepository.FindOneAsync(x => x.Id == model.UserId);
            if (user == null) return new ServiceResponse<UserDTO>(false, "user not found");

            user.PasswordHash = _hasher.CreateHash(model.NewPassword);
            tokenEntity.Expires = DateTime.UtcNow;

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.ResetPasswordTokenRepository.Update(tokenEntity);

            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<UserDTO>(true, "password updated successfully");
        }

        public async Task<ServiceResponse<UserDTO>> UpdateUserAsync(Guid userId, UpdateProfileModel model)
        {
            var userEntity = await _unitOfWork.UserRepository.Find(x => x.Id == userId).Include(x => x.Role).FirstOrDefaultAsync();
            if (userEntity == null) return new ServiceResponse<UserDTO>(false, "user not found");
            userEntity.UserName = model.UserName;
            userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.EmailAddress = model.EmailAddress;
            userEntity.PhoneNumber = model.PhoneNumber;

            // generate new jwt token
            var jwtToken = _tokenService.GenerateJwtToken(userEntity);

            var data = _mapper.Map<UserDTO>(userEntity);
            data.AccessToken = jwtToken;

            _unitOfWork.UserRepository.Update(userEntity, true);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<UserDTO>(true, "user updated successfully") { Data = data };
        }

        public async Task<ServiceResponse<UserDTO>> ChangePasswordAsync(Guid userId, UpdatePasswordModel model)
        {
            var user = await _unitOfWork.UserRepository.FindByIdAsync(userId);
            if (user == null) return new ServiceResponse<UserDTO>(false, "user not found");
            if (user.PasswordHash != _hasher.CreateHash(model.OldPassword)) return new ServiceResponse<UserDTO>(false, "incorrect old password");
            user.PasswordHash = _hasher.CreateHash(model.NewPassword);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<UserDTO>(true, "password changed successfully");
        }

        public async Task<ServiceResponse<CompanyDTO>> GetCompanyAsync(Guid userId)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.Id == userId).Include(x => x.Company).FirstOrDefaultAsync();
            if (user == null) return new ServiceResponse<CompanyDTO>(false, "user not found");
            if (user.Company == null) return new ServiceResponse<CompanyDTO>(false, "company not found");
            var dto = _mapper.Map<CompanyDTO>(user.Company);
            dto.LogoName = user.Company.HasLogo ? $"{CustomEnvironment.ApiUrl}/{userId}/logo/{dto.LogoName}" : null;

            return new ServiceResponse<CompanyDTO>(true) { Data = dto };
        }

        public async Task<ServiceResponse<CompanyDTO>> UpdateCompanyAsync(Guid userId, UpdateCompanyModel model)
        {
            if (model == null) return new ServiceResponse<CompanyDTO>(false);
            var user = await _unitOfWork.UserRepository.Find(x => x.Id == userId).Include(x => x.Company).FirstOrDefaultAsync();
            if (user == null) return new ServiceResponse<CompanyDTO>(false, "user not found");
            if (user.Company != null && user.Company.Slug != model.Slug && await _unitOfWork.CompanyRepository.Find(x => x.Slug == model.Slug).AnyAsync())
                return new ServiceResponse<CompanyDTO>(false, "slug already taken before", errorCode: ErrorCodes.DuplicatedCompanySlug);

            var data = new CompanyDTO();
            if (user.Company != null)
            {
                user.Company.Name = model.Name;
                user.Company.Slug = model.Slug;
                data = _mapper.Map<CompanyDTO>(user.Company);
            }
            else
            {
                var company = _mapper.Map<Company>(model);

                var menu = await _unitOfWork.MenuRepository.FindOneAsync(x => x.UserId == userId);
                menu.Company = company;
                _unitOfWork.MenuRepository.Update(menu);

                user.Company = company;
                data = _mapper.Map<CompanyDTO>(company);
            }

            if (model.LogoFile != null && await _imageService.SaveCompanyLogoAsync(model.LogoFile, userId, true))
            {
                user.Company.LogoName = model.LogoFile.FileName;
                data.LogoName = model.LogoFile.FileName;
            }

            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            // clear cache
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_tr");
            _redisCacheService.Remove(RedisKeyPrefixes.MENU + userId.ToString() + "_en");

            return new ServiceResponse<CompanyDTO>(true) { Data = data };
        }
    }
}