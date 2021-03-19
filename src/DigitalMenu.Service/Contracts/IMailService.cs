using DigitalMenu.Entity.DTOs;
using System.Threading.Tasks;

namespace DigitalMenu.Service.Contracts
{
    public interface IMailService
    {
        string Host { get; set; }
        int Port { get; set; }
        bool UseSsl { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        Task Send(MailDTO data);
    }
}