using System;
using System.Threading.Tasks;

namespace DigitalMenu.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}