using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using DigitalMenu.Core.Model;
using DigitalMenu.Core.Security.Contracts;
using Microsoft.Extensions.Options;

namespace DigitalMenu.Core.Security
{
    public class Encryption : IEncryption
    {
        private readonly IOptions<EncryptionConfig> _encryptionConfig;

        public Encryption(IOptions<EncryptionConfig> encryptionConfig)
        {
            _encryptionConfig = encryptionConfig;
        }
    
        public string EncryptText(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;

                using (var provider = new TripleDESCryptoServiceProvider())
                {
                    provider.Key = Encoding.ASCII.GetBytes(_encryptionConfig.Value.PrivateKey.Substring(0, 16));
                    provider.IV = Encoding.ASCII.GetBytes(_encryptionConfig.Value.PrivateKey.Substring(8, 8));

                    var encryptedBinary = EncryptTextToMemory(text, provider.Key, provider.IV);
                    return Convert.ToBase64String(encryptedBinary);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encryption/EncryptText");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex?.InnerException.Message);
                return text;
            }
        }

        public string DecryptText(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;

                using (var provider = new TripleDESCryptoServiceProvider())
                {
                    provider.Key = Encoding.ASCII.GetBytes(_encryptionConfig.Value.PrivateKey.Substring(0, 16));
                    provider.IV = Encoding.ASCII.GetBytes(_encryptionConfig.Value.PrivateKey.Substring(8, 8));

                    var buffer = Convert.FromBase64String(text);
                    return DecryptTextFromMemory(buffer, provider.Key, provider.IV);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encryption/DecryptText");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex?.InnerException.Message);
                return text;
            }
        }

        private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    var toEncrypt = Encoding.Unicode.GetBytes(data);
                    cs.Write(toEncrypt, 0, toEncrypt.Length);
                    cs.FlushFinalBlock();
                }

                return ms.ToArray();
            }
        }

        private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    using (var sr = new StreamReader(cs, Encoding.Unicode))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}