using System.Threading.Tasks;

namespace DigitalMenu.Core.Security.Contracts
{
    public interface IEncryption
    {
        string EncryptText(string text);
        string DecryptText(string text);
    }
}