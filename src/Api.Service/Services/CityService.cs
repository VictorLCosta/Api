using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.DTO.City;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using AutoMapper;

namespace Api.Service.Services
{
    public class CityService : ICityService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public CityService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _uow.Cities.Remove(id);
            await _uow.Commit();

            return result;
        }

        public async Task<CityDto> Get(Guid id)
        {
            return _mapper.Map<CityDto>(await _uow.Cities.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _uow.Cities.GetAllAsync());
        }

        public async Task<CityDto> GetByIbge(int ibgeCode)
        {
            return _mapper.Map<CityDto>(await _uow.Cities.GetByIbgeCodeAsync(ibgeCode));
        }

        public async Task<CreateCityResultDto> Post(CreateCityDto model)
        {
            var city = _mapper.Map<City>(model);

            var result = await _uow.Cities.AddAsync(city);
            await _uow.Commit();

            return _mapper.Map<CreateCityResultDto>(result);
        }

        public async Task<UpdateCityResultDto> Put(UpdateCityDto model)
        {
            var city = _mapper.Map<City>(model);

            var result = await _uow.Cities.Update(city);
            await _uow.Commit();

            return _mapper.Map<UpdateCityResultDto>(result);
        }
    }
}