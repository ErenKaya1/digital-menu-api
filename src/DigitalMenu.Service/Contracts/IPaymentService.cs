using System;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Subscription;

namespace DigitalMenu.Service.Contracts
{
    public interface IPaymentService
    {
        Task<ServiceResponse<double>> PayAsync(Guid userId, RenewSubscriptionModel model, string ipAddress);
        Task<ServiceResponse<object>> InsertPaymentAsync(Guid userId, Guid subscriptionId, double amount);
    }
}