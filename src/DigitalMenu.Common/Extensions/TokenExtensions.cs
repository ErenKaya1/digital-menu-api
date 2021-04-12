using System;
using System.IdentityModel.Tokens.Jwt;

namespace DigitalMenu.Common.Extensions
{
    public static class TokenExtensions
    {
        public static bool IsExpired(this JwtSecurityToken token) => ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds() >= token.Payload.Exp;
    }
}