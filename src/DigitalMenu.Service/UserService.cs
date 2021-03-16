using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}