using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using System;
using System.Threading.Tasks;

namespace DigitalMenu.Service.Contracts
{
    public interface ITokenService
    {
        string GenerateJwtToken(DMUser user);
        RefreshToken GenerateRefreshToken(string ipAddress);
        Task RevokeRefreshTokensAsync(Guid userId, string ipAddress);
        Task<ServiceResponse<ResetPasswordTokenDTO>> GenerateResetPasswordTokenAsync(Guid userId);
        Task RevokeRefreshTokensAsync(Guid userId, string newRefreshToken, string ipAddress);
    }
}