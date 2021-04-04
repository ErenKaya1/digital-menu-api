using System;
using System.Threading.Tasks;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly DMContext _dbContext;
        private readonly IEncryption _encryption;
        private IRepository<DMUser> _userRepository;
        private IRepository<RefreshToken> _refreshTokenRepository;
        private IRepository<DMRole> _roleRepository;
        private IRepository<Subscription> _subscriptionRepository;
        private IRepository<ResetPasswordToken> _resetPassowordTokenRepository;
        private IRepository<SubscriptionType> _subscriptionTypeRepository;
        private IRepository<Category> _categoryRepository;

        public IRepository<DMUser> UserRepository => _userRepository ??= new Repository<DMUser>(_dbContext, _encryption);
        public IRepository<RefreshToken> RefreshTokenRepository => _refreshTokenRepository ??= new Repository<RefreshToken>(_dbContext, _encryption);
        public IRepository<DMRole> RoleRepository => _roleRepository ??= new Repository<DMRole>(_dbContext, _encryption);
        public IRepository<Subscription> SubscriptionRepository => _subscriptionRepository ??= new Repository<Subscription>(_dbContext, _encryption);
        public IRepository<ResetPasswordToken> ResetPasswordTokenRepository => _resetPassowordTokenRepository ??= new Repository<ResetPasswordToken>(_dbContext, _encryption);
        public IRepository<SubscriptionType> SubscriptionTypeRepository => _subscriptionTypeRepository ??= new Repository<SubscriptionType>(_dbContext, _encryption);
        public IRepository<Category> CategoryRepository => _categoryRepository ??= new Repository<Category>(_dbContext, _encryption);

        public UnitOfWork(DMContext dbContext, IEncryption encryption)
        {
            _dbContext = dbContext;
            _encryption = encryption;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new DbUpdateException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        protected async virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    await _dbContext.DisposeAsync();

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}