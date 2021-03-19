using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Entity.DTOs;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DigitalMenu.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHasher _hasher;

        public TokenService(IOptions<JwtSettings> jwtSettings, IUnitOfWork unitOfWork, IHasher hasher)
        {
            _jwtSettings = jwtSettings;
            _unitOfWork = unitOfWork;
            _hasher = hasher;
        }

        public string GenerateJwtToken(DMUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = Encoding.ASCII.GetBytes(_jwtSettings.Value.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtSettings.Value.Issuer,
                Audience = _jwtSettings.Value.Audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(string ipAddress)
        {
            using var provider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            provider.GetBytes(randomBytes);

            return new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(14),
                CreatedAt = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        public async Task RevokeRefreshTokensAsync(Guid userId, string ipAddress)
        {
            var tokens = await _unitOfWork.RefreshTokenRepository.Find(x => x.UserId == userId).ToListAsync();

            foreach (var token in tokens)
            {
                if (!token.IsActive || token.IsExpired) continue;
                token.RevokedAt = DateTime.UtcNow;
                token.RevokedByIp = ipAddress;
                _unitOfWork.RefreshTokenRepository.Update(token);
            }

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ServiceResponse<ResetPasswordTokenDTO>> GenerateResetPasswordToken(ForgotPasswordModel model)
        {
            var user = await _unitOfWork.UserRepository.Find(x => x.EmailAddress == model.EmailAddress, true).FirstOrDefaultAsync();
            if (user == null) return new ServiceResponse<ResetPasswordTokenDTO>(false, "user not found");

            using var provider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[16];
            provider.GetBytes(randomBytes);
            var token = Convert.ToBase64String(randomBytes);

            var entity = new ResetPasswordToken
            {
                Id = Guid.NewGuid(),
                TokenHash = _hasher.CreateHash(token),
                Expires = DateTime.UtcNow.AddMinutes(15),
                UserId = user.Id
            };

            _unitOfWork.ResetPasswordTokenRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            var data = new ResetPasswordTokenDTO
            {
                UserId = user.Id,
                Token = token
            };

            return new ServiceResponse<ResetPasswordTokenDTO>(true) { Data = data };
        }
    }
}