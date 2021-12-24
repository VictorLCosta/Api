using System;
using System.Threading.Tasks;
using Api.Data.Interfaces;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<City> GetByIbgeCodeAsync(int code)
        {
            return await _context.Cities
                .Include(x => x.State)
                .SingleOrDefaultAsync(x => x.IbgeCode == code);
        }

        public async Task<City> GetByIdAsync(Guid id)
        {
            return await _context.Cities
                .Include(x => x.State)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}