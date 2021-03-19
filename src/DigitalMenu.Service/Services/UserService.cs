using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Entity.Enum;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHasher _hasher;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserService(IUnitOfWork unitOfWork, IHasher hasher, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _hasher = hasher;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ServiceResponse<UserDTO>> InsertUserAsync(RegisterModel model, string ipAddress)
        {
            // check if username and email are valid
            if (await _unitOfWork.UserRepository.Find(x => x.UserName == model.UserName || x.EmailAddress == model.EmailAddress).AnyAsync())
                return new ServiceResponse<UserDTO>(false, "register failed", "username or email is already taken");

            var entity = _mapper.Map<DMUser>(model);
            entity.Id = Guid.NewGuid();
            entity.PasswordHash = _hasher.CreateHash(model.Password);

            // add role to user and save
            entity.RoleId = (await _unitOfWork.RoleRepository.FindOneAsync(x => x.RoleName.ToLower() == "customer")).Id;
            _unitOfWork.UserRepository.Add(entity);

            // start trial version and save
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.UtcNow.Date,
                EndDate = DateTime.UtcNow.Date.AddDays(14),
                InTrialModel = true,
                SubscriptionStatus = SubscriptionStatus.Active,
                UserId = entity.Id
            };

            _unitOfWork.SubscriptionRepository.Add(subscription);

            // generate jwt and refresh token
            var jwtToken = _tokenService.GenerateJwtToken(entity);
            var refreshToken = _tokenService.GenerateRefreshToken(ipAddress);
            refreshToken.UserId = entity.Id;
            _unitOfWork.RefreshTokenRepository.Add(refreshToken);

            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<UserDTO>(entity);
            data.AccessToken = jwtToken;
            data.RefreshToken = refreshToken.Token;

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
            if (user == null) return new ServiceResponse<UserDTO>(false, "authentication failed", "username or password incorrect");

            // if correct, generate jwt and refresh token
            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(ipAddress);
            refreshToken.UserId = user.Id;
            _unitOfWork.RefreshTokenRepository.Add(refreshToken);
            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<UserDTO>(user);
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
            data.AccessToken = jwtToken;
            data.RefreshToken = newRefreshToken.Token;

            return new ServiceResponse<UserDTO>(true) { Data = data };
        }
    }
}