using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTO.City;

namespace Api.Service.Interfaces
{
    public interface ICityService
    {
        Task<CityDto> Get(Guid id);
        Task<CityDto> GetByIbge(int ibgeCode);
        Task<IEnumerable<CityDto>> GetAll();
        Task<CreateCityResultDto> Post(CreateCityDto city);
        Task<UpdateCityResultDto> Put(UpdateCityDto city);
        Task<bool> Delete(Guid id);
    }
}