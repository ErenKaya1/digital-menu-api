using System;
using System.Threading.Tasks;
using DigitalMenu.Entity.Entities;

namespace DigitalMenu.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        IRepository<DMUser> UserRepository { get; }
    }
}