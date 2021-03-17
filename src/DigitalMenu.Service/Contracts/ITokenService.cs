using DigitalMenu.Entity.Entities;

namespace DigitalMenu.Service.Contracts
{
    public interface ITokenService
    {
        string GenerateJwtToken(DMUser user);
        RefreshToken GenerateRefreshToken(string ipAddress);
    }
}