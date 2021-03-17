using System;
using System.Threading.Tasks;
using AutoMapper;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

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

        public async Task<ServiceResponse<UserDTO>> InsertUserAsync(UserDTO dto)
        {
            var entity = _mapper.Map<DMUser>(dto);
            entity.PasswordHash = _hasher.CreateHash(dto.Password);
            _unitOfWork.UserRepository.Add(entity, true);
            await _unitOfWork.SaveChangesAsync();

            return new ServiceResponse<UserDTO>(true, "user created successfully.");
        }

        public async Task<ServiceResponse<UserDTO>> AuthenticateAsync(LoginModel model)
        {
            var user = await _unitOfWork.UserRepository.FindOneAsync(x => x.UserName == model.UserName && x.PasswordHash == _hasher.CreateHash(model.Password), true);
            if (user == null) return new ServiceResponse<UserDTO>(false, "user not found.");

            var jwtToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = Guid.NewGuid();

            var data = _mapper.Map<UserDTO>(user);
            data.AccessToken = jwtToken;
            data.RefreshToken = refreshToken.ToString();

            return new ServiceResponse<UserDTO>(true, "authenticated successfully.")
            {
                Data = data
            };
        }
    }
}