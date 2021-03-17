using System.Threading.Tasks;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface IUserService
    {
        Task<ServiceResponse<UserDTO>> InsertUserAsync(UserDTO dto);
        Task<ServiceResponse<UserDTO>> AuthenticateAsync(LoginModel dto, string ipAddress);
    }
}