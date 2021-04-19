using System.Threading.Tasks;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface IMenuService
    {
        Task<ServiceResponse<MenuDTO>> GetMenuByCompanySlugAsync(string companySlug, string cultureCode, string currency);
    }
}