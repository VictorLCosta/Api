using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task<User> Post(User user);
        Task<User> Put(User user);
        Task<bool> Delete(Guid id);
    }
}