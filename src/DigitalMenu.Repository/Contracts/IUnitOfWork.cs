using System;
using System.Threading.Tasks;
using DigitalMenu.Entity.Entities;

namespace DigitalMenu.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
        IRepository<DMUser> UserRepository { get; }
        IRepository<RefreshToken> RefreshTokenRepository { get; }
        IRepository<DMRole> RoleRepository { get; }
        IRepository<Subscription> SubscriptionRepository { get; }
    }
}