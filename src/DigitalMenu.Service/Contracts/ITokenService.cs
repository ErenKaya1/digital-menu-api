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
    }
}