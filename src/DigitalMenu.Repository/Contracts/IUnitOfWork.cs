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
        IRepository<ResetPasswordToken> ResetPasswordTokenRepository { get; }
        IRepository<SubscriptionType> SubscriptionTypeRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<CategoryTranslation> CategoryTranslationRepository { get; }
        IRepository<Culture> CultureRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<ProductTranslation> ProductTranslationRepository { get; }
        IRepository<Menu> MenuRepository { get; }
        IRepository<Company> CompanyRepository { get; }
    }
}