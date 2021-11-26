using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Data.Interfaces;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<T> GetAsync(Guid id)
        {
            try
            {
                return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _context.Set<T>().AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
                if(entity == null)
                    return false;

                var result = _context.Set<T>().Remove(entity);
                return true;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                var result = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == entity.Id);
                if(result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return entity;
        }
    }
}