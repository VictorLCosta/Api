using System;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Data.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        Task<City> GetByIdAsync(Guid id);
        Task<City> GetByIbgeCodeAsync(int code);
    }
}