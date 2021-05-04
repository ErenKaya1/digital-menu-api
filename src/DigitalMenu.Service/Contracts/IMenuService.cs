using System;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.Menu;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface IMenuService
    {
        Task<ServiceResponse<MenuDTO>> GetMenuByCompanySlugAsync(string companySlug, string cultureCode, string currency);
        Task<ServiceResponse<object>> UpdateMenuThemeAsync(Guid userId, MenuThemeModel model);
        Task<ServiceResponse<MenuThemeModel>> GetMenuThemeAsync(Guid userId);
    }
}