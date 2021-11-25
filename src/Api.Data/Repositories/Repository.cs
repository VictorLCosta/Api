using System;
using System.Threading.Tasks;
using Api.Data.Interfaces;
using Api.Domain.Entities;

namespace Api.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                await _context.Set<T>().AddAsync(entity);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return entity;
        }

        public Task<System.Collections.Generic.IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}