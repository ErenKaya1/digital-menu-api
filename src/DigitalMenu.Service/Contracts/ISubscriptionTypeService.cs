using System.Threading.Tasks;
using DigitalMenu.Service;

namespace DigitalMenu.Service.Contracts
{
    public interface ISubscriptionTypeService
    {
        Task<ServiceResponse<object>> GetSubscriptionListAsync();
    }
}