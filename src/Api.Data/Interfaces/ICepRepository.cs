using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.Interfaces
{
    public interface ICepRepository : IRepository<Cep>
    {
        Task<Cep> GetByIdAsync(Guid id);
        Task<Cep> GetByCepAsync(string cep);
    }
}