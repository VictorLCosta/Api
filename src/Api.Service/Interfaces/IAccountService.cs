using System.Threading.Tasks;
using Api.Domain.DTO.Account;
using Api.Domain.Entities;

namespace Api.Service.Interfaces
{
    public interface IAccountService
    {
        Task<object> FindByLogin(LoginDto model);
    }
}