using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Service.Contracts
{
    public interface IImageService
    {
        Task<bool> SaveCompanyLogoAsync(IFormFile file, bool replace);
        Task<bool> SaveCategoryImageAsync(IFormFile file, Guid userId);
    }
}