using System;
using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.DTO.Cep;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class CepService : ICepService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CepService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _uow.Ceps.Remove(id);
            await _uow.Commit();

            return result;
        }

        public async Task<CepDto> Get(Guid id)
        {
            return _mapper.Map<CepDto>(await _uow.Ceps.GetByIdAsync(id));
        }

        public async Task<CepDto> Get(string cep)
        {
            return _mapper.Map<CepDto>(await _uow.Ceps.GetByCepAsync(cep));
        }

        public async Task<CreateCepResultDto> Post(CreateCepDto model)
        {
            var cep = _mapper.Map<Cep>(model);

            return _mapper.Map<CreateCepResultDto>(await _uow.Ceps.AddAsync(cep));
        }

        public async Task<UpdateCepResultDto> Put(UpdateCepDto model)
        {
            var cep = _mapper.Map<Cep>(model);

            return _mapper.Map<UpdateCepResultDto>(await _uow.Ceps.Update(cep));
        }
    }
}