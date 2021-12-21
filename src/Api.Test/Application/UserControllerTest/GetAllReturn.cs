using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetAllReturn
    {
        private UsersController _controller;

        [Fact]
        public async Task IsPossibleGetAll()
        {
            Faker faker = new();

            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<UserDto>() 
                {
                    new UserDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Person.FullName,
                        Email = faker.Person.Email,
                        CreatedAt = DateTime.UtcNow
                    },
                    new UserDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Person.FullName,
                        Email = faker.Person.Email,
                        CreatedAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(resultValue.Count() == 2);
        }
    }
}