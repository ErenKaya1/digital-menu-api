using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ServiceResponse<List<SubscriptionDTO>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}