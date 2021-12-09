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
    public class CreateReturn
    {
        private UsersController _controller;

        [Fact]
        public async Task IsPossibleCreate()
        {
            Faker faker = new();

            var serviceMock = new Mock<IUserService>();

            var name = faker.Person.FullName;
            var email = faker.Person.Email;

            serviceMock.Setup(x => x.Post(It.IsAny<UserDto>())).ReturnsAsync
            (
                new CreateUserResultDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreatedAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMock.Object);

            Mock<IUrlHelper> url = new();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var userDto = new UserDto() 
            {
                Name = name,
                Email = email,
            };

            var result = await _controller.Post(userDto);

            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CreateUserResultDto;

            Assert.Equal(resultValue.Name, userDto.Name);
            Assert.Equal(resultValue.Email, userDto.Email);
        }
    }
}