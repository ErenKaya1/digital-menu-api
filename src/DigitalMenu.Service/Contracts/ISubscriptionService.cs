using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface ISubscriptionService
    {
        Task<ServiceResponse<List<SubscriptionDTO>>> GetAllAsync();
        Task UpdateReminderMailSentStatusByIdAsync(Guid id); 
    }
}