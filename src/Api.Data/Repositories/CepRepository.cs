using System;
using System.Threading.Tasks;
using Api.Data.Interfaces;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class CepRepository : Repository<Cep>, ICepRepository
    {
        public CepRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<Cep> GetByCepAsync(string cep)
        {
            return await _context.Ceps
                .Include(x => x.City)
                .ThenInclude(x => x.State)
                .SingleOrDefaultAsync(x => x.CEP == cep);
        }

        public async Task<Cep> GetByIdAsync(Guid id)
        {
            return await _context.Ceps
                .Include(x => x.City)
                .ThenInclude(x => x.State)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}