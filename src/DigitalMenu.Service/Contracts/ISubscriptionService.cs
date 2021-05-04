using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Common.Enum;
using DigitalMenu.Core.Model.Subscription;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface ISubscriptionService
    {
        Task<ServiceResponse<List<SubscriptionDTO>>> GetAllAsync();
        Task UpdateReminderMailSentStatusByIdAsync(Guid id);
        Task<ServiceResponse<SubscriptionStatus>> CheckSubscriptionAsync(Guid userId);
        Task<ServiceResponse<object>> RenewSubscriptionAsync(Guid userId, RenewSubscriptionModel model, string ipAddress);
    }
}