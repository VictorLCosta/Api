using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTO.User;

namespace Api.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<CreateUserResultDto> Post(UserDto model);
        Task<UpdateUserResultDto> Put(UserDto model);
        Task<bool> Delete(Guid id);
    }
}