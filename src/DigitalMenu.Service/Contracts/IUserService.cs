using System;
using System.Threading.Tasks;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Entity.DTOs;

namespace DigitalMenu.Service.Contracts
{
    public interface IUserService
    {
        Task<ServiceResponse<UserDTO>> InsertUserAsync(RegisterModel model, string ipAddress);
        Task<ServiceResponse<UserDTO>> AuthenticateAsync(LoginModel dto, string ipAddress);
        Task<ServiceResponse<UserDTO>> RefreshTokenAsync(string token, string ipAddress);
        Task<ServiceResponse<Guid>> GetUserIdByEmailAsync(string emailAddress);
    }
}