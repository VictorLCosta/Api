using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<bool> Remove(T entity);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}