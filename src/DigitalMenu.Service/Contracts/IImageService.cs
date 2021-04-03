using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DigitalMenu.Service.Contracts
{
    public interface IImageService
    {
        Task SaveCompanyLogoAsync(IFormFile file, bool replace);
    }
}