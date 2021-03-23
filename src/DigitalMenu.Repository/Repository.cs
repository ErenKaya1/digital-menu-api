using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using DigitalMenu.Core.Attribute;
using DigitalMenu.Core.Security.Contracts;
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
        private readonly IEncryption _encryption;

        public Repository(DMContext dbContext, IEncryption encryption)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _encryption = encryption;
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

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(T entity, bool isEncrypt = false)
        {
            if (isEncrypt)
                entity = EncryptEntityFields(entity, _dbContext);

            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void AddRange(List<T> entities, bool isEncrypt = false)
        {
            if (isEncrypt)
                entities = EncryptEntityFields(entities, _dbContext);

            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity, bool isEncrypt = false)
        {
            if (isEncrypt)
                entity = EncryptEntityFields(entity, _dbContext);

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        private T EncryptEntityFields(T entity, DMContext dbContext)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attrs = property.GetCustomAttributes(false);
                foreach (var attr in attrs)
                {
                    if (attr is EncryptedAttribute)
                    {
                        var encryptedValue = _encryption.EncryptText(dbContext.Entry(entity).Property(property.Name).CurrentValue.ToString());
                        dbContext.Entry(entity).Property(property.Name).CurrentValue = encryptedValue;
                        // entity.GetType().GetProperty(property.Name).SetValue(entity, encryptedValue);
                    }
                }
            }

            return entity;
        }

        private List<T> EncryptEntityFields(List<T> entities, DMContext dbContext)
        {
            foreach (var entity in entities)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    var attrs = property.GetCustomAttributes(false);
                    foreach (var attr in attrs)
                    {
                        if (attr is EncryptedAttribute)
                        {
                            var encryptedValue = _encryption.EncryptText(dbContext.Entry(entity).Property(property.Name).CurrentValue.ToString());
                            dbContext.Entry(entity).Property(property.Name).CurrentValue = encryptedValue;
                            // entity.GetType().GetProperty(property.Name).SetValue(entity, encryptedValue);
                        }
                    }
                }
            }

            return entities;
        }
    }
}