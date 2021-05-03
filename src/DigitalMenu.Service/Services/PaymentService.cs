using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;

namespace DigitalMenu.Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}