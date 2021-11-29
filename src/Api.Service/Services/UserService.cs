using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Api.Service.PasswordHasher;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUow _unit;
        private readonly Hasher _hasher;

        public UserService(IUow unit, Hasher hasher)
        {
            _unit = unit;
            _hasher = hasher;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _unit.Users.Remove(id);
        }

        public async Task<User> Get(Guid id)
        {
            return await _unit.Users.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unit.Users.GetAllAsync();
        }

        public async Task<User> Post(User user)
        {
            user.PasswordHash = await _hasher.HashPassword(user.ProvidedPassword);

            return await _unit.Users.AddAsync(user);
        }

        public async Task<User> Put(User user)
        {
            user.PasswordHash = await _hasher.HashPassword(user.ProvidedPassword);

            return await _unit.Users.Update(user);
        }
    }
}