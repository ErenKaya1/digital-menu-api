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
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
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

        public IQueryable<T> FindAll(bool isDecrypt = false)
        {
            var entities = _dbSet.AsQueryable();

            if (isDecrypt)
                entities = DecryptEntityFields(entities.ToList()).AsQueryable();

            return entities;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool isDecrypt = false)
        {
            var entities = _dbSet.AsQueryable();

            if (isDecrypt)
                entities = DecryptEntityFields(entities.ToList()).AsQueryable();

            return entities.Where(predicate).AsQueryable();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, bool isDecrypt = false)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null) return null;

            if (isDecrypt)
                entity = DecryptEntityFields(entity);

            return entity;
        }

        public void Add(T entity, bool isEncrypt = false)
        {
            if (isEncrypt)
                entity = EncryptEntityFields(entity);

            _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void AddRange(List<T> entities, bool isEncrypt = false)
        {
            if (isEncrypt)
                entities = EncryptEntityFields(entities);

            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity, bool isEncrypt = false)
        {
            if (isEncrypt)
                entity = EncryptEntityFields(entity);                

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        private T EncryptEntityFields(T entity)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attrs = property.GetCustomAttributes(false);
                foreach (var attr in attrs)
                {
                    if (attr is EncryptedAttribute)
                    {
                        var encryptedValue = _encryption.EncryptText(entity.GetType().GetProperty(property.Name).GetValue(entity, null).ToString());
                        entity.GetType().GetProperty(property.Name).SetValue(entity, encryptedValue);
                    }
                }
            }

            return entity;
        }

        private List<T> EncryptEntityFields(List<T> entities)
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
                            var encryptedValue = _encryption.EncryptText(entity.GetType().GetProperty(property.Name).GetValue(entity, null).ToString());
                            entity.GetType().GetProperty(property.Name).SetValue(entity, encryptedValue);
                        }
                    }
                }
            }

            return entities;
        }

        private T DecryptEntityFields(T entity)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attrs = property.GetCustomAttributes(false);
                foreach (var attr in attrs)
                {
                    if (attr is EncryptedAttribute)
                    {
                        var decryptedValue = _encryption.DecryptText(entity.GetType().GetProperty(property.Name).GetValue(entity, null).ToString());
                        entity.GetType().GetProperty(property.Name).SetValue(entity, decryptedValue);
                    }
                }
            }

            return entity;
        }

        private List<T> DecryptEntityFields(List<T> entities)
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
                            var decryptedValue = _encryption.DecryptText(entity.GetType().GetProperty(property.Name).GetValue(entity, null).ToString());
                            entity.GetType().GetProperty(property.Name).SetValue(entity, decryptedValue);
                        }
                    }
                }
            }

            return entities;
        }
    }
}