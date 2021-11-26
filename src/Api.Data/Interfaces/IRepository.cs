using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<bool> Remove(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<bool> ExistAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}