using AutoMapper;
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

        public UserService(IUnitOfWork unitOfWork, IHasher hasher, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hasher = hasher;
            _mapper = mapper;
        }

        public ServiceResponse<DMUser> InsertUser(UserDTO dto)
        {
            var entity = _mapper.Map<DMUser>(dto);

            throw new System.NotImplementedException();
        }
    }
}