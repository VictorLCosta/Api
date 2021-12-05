using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.DTO.User;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Api.Service.PasswordHasher;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUow _unit;
        private readonly IMapper _mapper;
        private readonly Hasher _hasher;

        public UserService(IUow unit, IMapper mapper, Hasher hasher)
        {
            _unit = unit;
            _mapper = mapper;
            _hasher = hasher;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _unit.Users.Remove(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var user = await _unit.Users.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var list = await _unit.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(list);
        }

        public async Task<CreateUserResultDto> Post(UserDto model)
        {
            var user = _mapper.Map<User>(model);

            user.PasswordSalt = _hasher.CreateSalt();
            user.PasswordHash = await _hasher.HashPassword(model.Password, user.PasswordSalt);

            return _mapper.Map<CreateUserResultDto>(await _unit.Users.AddAsync(user));
        }

        public async Task<UpdateUserResultDto> Put(UserDto model)
        {
            var user = _mapper.Map<User>(model);

            user.PasswordSalt = _hasher.CreateSalt();
            user.PasswordHash = await _hasher.HashPassword(model.Password, user.PasswordSalt);

            return _mapper.Map<UpdateUserResultDto>(await _unit.Users.Update(user));
        }
    }
}