using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.DTO.User;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUow _unit;

        public AccountService(IUow unit)
        {
            _unit = unit;
        }

        public async Task<object> FindByLogin(LoginDto model)
        {
            User baseUser = new();
            if(model != null && string.IsNullOrEmpty(model.Email))
            {
                baseUser = await _unit.Users.FindBy(x => x.Email.Equals(model.Email)).FirstOrDefaultAsync();
                if(baseUser == null)
                {
                    return null;
                }
                else 
                {
                    return baseUser;
                }
            }

            return null;
        }
    }
}