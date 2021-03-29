using System;
using System.Text;
using DigitalMenu.Core.Security.Contracts;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DigitalMenu.Core.Security
{
    public class Hasher : IHasher
    {
        public string Salt { get; set; }

        public string CreateHash(string value)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(Salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            );

            return Convert.ToBase64String(valueBytes);
        }
    }
}