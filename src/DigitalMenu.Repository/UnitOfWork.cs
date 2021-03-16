using System;
using System.Threading.Tasks;
using DigitalMenu.Data.Context;
using DigitalMenu.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly DMContext _dbContext;

        public UnitOfWork(DMContext dbContext)
        {
            if (dbContext == null) return;
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                throw new DbUpdateException();
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