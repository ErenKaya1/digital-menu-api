namespace DigitalMenu.Core.Security.Contracts
{
    public interface IHasher
    {
        string CreateHash(string value);
    }
}