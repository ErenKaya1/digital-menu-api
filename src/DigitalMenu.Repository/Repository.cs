using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.Entities.Base;
using DigitalMenu.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DMContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DMContext dbContext)
        {
            if (dbContext == null) return;

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void AddRange(List<T> entities)
        {
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
    }
}