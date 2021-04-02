using System;
using System.Security.Claims;
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
        Task<ServiceResponse<Guid>> SendResetPasswordMailAsync(string emailAddress);
        Task<ServiceResponse<UserDTO>> ResetPasswordAsync(Guid userId, string newPassword, string resetPasswordToken);
        Task<ServiceResponse<UserDTO>> UpdateUserAsync(Guid userId, UpdateProfileModel model);
        Task<ServiceResponse<UserDTO>> ChangePasswordAsync(Guid userId, UpdatePasswordModel model);
        Task<ServiceResponse<CompanyDTO>> GetCompanyAsync(Guid userId);
        Task<ServiceResponse<CompanyDTO>> UpdateCompanyAsync(Guid userID, UpdateCompanyModel model);
    }
}