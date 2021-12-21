using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTO.User;
using Api.Service.Interfaces;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test.Application.UserControllerTest
{
    public class GetReturn
    {
        private UsersController _controller;

        [Fact]
        public async Task IsPossibleGet()
        {
            Faker faker = new();

            var serviceMock = new Mock<IUserService>();
            var name = faker.Person.FullName;
            var email = faker.Person.Email;

            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreatedAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, name);
            Assert.Equal(resultValue.Email, email);
        }

        [Fact]
        public async Task MustReturnBadRequest()
        {
            var serviceMock = new Mock<IUserService>();

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Get(Guid.Empty);
            Assert.True(result is BadRequestObjectResult);

            var resultValue = ((BadRequestObjectResult)result).Value.ToString();
            Assert.True(resultValue.Equals("ID inválido"));

        }
    }
}