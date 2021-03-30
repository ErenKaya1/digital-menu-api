using System.Threading.Tasks;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service.Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private readonly IUnitOfWork _unitOfwork;

        public SubscriptionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        public Task<ServiceResponse<object>> GetSubscriptionListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}