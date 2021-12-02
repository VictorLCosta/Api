using System.Threading.Tasks;
using Api.Data.Transactions;
using Api.Domain.DTO.User;
using Api.Domain.Entities;
using Api.Service.Interfaces;
using Api.Service.PasswordHasher;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUow _unit;
        private readonly ITokenService _tokenService;
        private readonly Hasher _hasher;

        public AccountService(IUow unit, ITokenService tokenService, Hasher hasher)
        {
            _unit = unit;
            _tokenService = tokenService;
            _hasher = hasher;
        }

        public async Task<object> FindByLogin(LoginDto model)
        {
            User baseUser = new();
            if(model != null && !string.IsNullOrEmpty(model.Email))
            {
                baseUser = await _unit.Users.FindBy(x => x.Email.Equals(model.Email)).FirstOrDefaultAsync();
                if(baseUser == null)
                    return null;

                var result = await _hasher.VerifyPassword(model.Password, baseUser.PasswordHash, baseUser.PasswordSalt);
                if(!result)
                    return null;
            
                return new {
                    user = baseUser,
                    token = _tokenService.GenerateToken(baseUser)
                };
            }

            return null;
        }
    }
}