using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTO.User;
using Api.Service.Interfaces;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Xunit;

namespace Api.Test.Application.UserControllerTest
{
    public class UpdateReturn
    {
        private UsersController _controller;

        [Fact]
        public async Task IsPossibleUpdate()
        {
            Faker faker = new();

            var serviceMock = new Mock<IUserService>();

            var name = faker.Person.FullName;
            var email = faker.Person.Email;

            serviceMock.Setup(x => x.Put(It.IsAny<UserDto>())).ReturnsAsync(
                new UpdateUserResultDto() 
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var userUpdateDto = new UserDto()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userUpdateDto);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UpdateUserResultDto;
            Assert.NotNull(resultValue);
            Assert.Equal(userUpdateDto.Name, resultValue.Name);
            Assert.Equal(userUpdateDto.Email, resultValue.Email);
        }

        [Theory]
        [InlineData(null, "asdasdasd", "")]
        public async Task MustReturnUnprocessable(string name, string email, string password)
        {
            Faker faker = new();

            var serviceMock = new Mock<IUserService>();

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "Email é um campo obrigatório");

            var userUpdateDto = new UserDto()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password
            };

            var result = await _controller.Put(userUpdateDto);
            Assert.True(result is UnprocessableEntityObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}