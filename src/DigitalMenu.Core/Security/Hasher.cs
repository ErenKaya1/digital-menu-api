using System;
using System.Text;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Security.Contracts;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;

namespace DigitalMenu.Core.Security
{
    public class Hasher : IHasher
    {
        private readonly IOptions<HasherConfig> _hasherConfig;

        public Hasher(IOptions<HasherConfig> hasherConfig)
        {
            _hasherConfig = hasherConfig;
        }

        public string CreateHash(string value)
        {
            var salt = _hasherConfig.Value.Salt;

            var valueBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            );

            return Convert.ToBase64String(valueBytes);
        }
    }
}