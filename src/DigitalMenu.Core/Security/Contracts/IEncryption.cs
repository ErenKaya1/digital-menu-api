using System.Threading.Tasks;

namespace DigitalMenu.Core.Security.Contracts
{
    public interface IEncryption
    {
        Task<string> EncryptText(string text);
        Task<string> DecryptText(string text);
    }
}