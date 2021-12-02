using Api.Domain.Entities;

namespace Api.Service.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}