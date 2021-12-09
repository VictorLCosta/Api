using System;
using System.Threading.Tasks;
using Api.Domain.DTO.Account;
using Api.Service.Interfaces;
using Bogus;
using Moq;
using Xunit;

namespace Api.Test.Services.LoginService
{
    public class WhenExecuteFindByLogin
    {
        private IAccountService _service;
        private Mock<IAccountService> _serviceMock;

        [Fact]
        public async Task IsPossibleExecuteFindByLogin()
        {
            Faker faker = new();

            var email = faker.Person.Email;

            var returnObj = new
            {
                authenticated = true,
                create = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                token = Guid.NewGuid(),
                userName = email,
                name = faker.Person.FullName,
                message = "Usuário Logado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<IAccountService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(returnObj);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}