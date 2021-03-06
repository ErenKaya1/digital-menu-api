using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalMenu.Entity.Entities.Base;

namespace DigitalMenu.Repository.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> FindAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task<T> FindOneAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity, bool isEncrypt = false);
        void AddRange(List<T> entities, bool isEncrypt = false);
        void Update(T entity, bool isEncrypt = false);
        void Delete(T entity);
        Task<T> FindByIdAsync(Guid id);
    }
}