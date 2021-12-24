using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTO.State;

namespace Api.Service.Interfaces
{
    public interface IStateService
    {
        Task<StateDto> Get(Guid id);
        Task<IEnumerable<StateDto>> GetAll();
    }
}