using System;
using System.Threading.Tasks;
using Api.Domain.DTO.Cep;

namespace Api.Service.Interfaces
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> Get(string cep);
        Task<CreateCepResultDto> Post(CreateCepDto cep);
        Task<UpdateCepResultDto> Put(UpdateCepDto cep);
        Task<bool> Delete(Guid id);
    }
}