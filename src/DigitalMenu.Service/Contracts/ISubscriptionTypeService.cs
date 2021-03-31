using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface ISubscriptionTypeService
    {
        Task<ServiceResponse<List<SubscriptionTypeDTO>>> GetSubscriptionTypesAsync(string cultureCode);
    }
}