using System.Threading.Tasks;
using Api.Data.Interfaces;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> FindByLogin(User user)
        {
            User baseUser = new();
            if(user != null && string.IsNullOrEmpty(user.Email))
            {
                baseUser = await _userRepository.FindBy(x => x.Email.Equals(user.Email)).FirstOrDefaultAsync();
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