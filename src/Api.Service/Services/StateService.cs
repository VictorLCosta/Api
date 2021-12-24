using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.DTO.State;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class StateService : IStateService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public StateService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<StateDto> Get(Guid id)
        {
            return _mapper.Map<StateDto>(await _uow.States.GetAsync(id));
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<StateDto>>(await _uow.States.GetAllAsync());
        }
    }
}