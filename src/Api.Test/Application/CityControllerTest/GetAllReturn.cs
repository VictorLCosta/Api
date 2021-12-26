using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTO.City;
using Api.Service.Interfaces;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test.Application.CityControllerTest
{
    public class GetAllReturn
    {
        private CityController _controller;

        [Fact]
        public async Task IsPossibleGetAll()
        {
            Faker faker = new("pt_BR");

            var serviceMock = new Mock<ICityService>();
            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<CityDto>() 
                {
                    new CityDto() {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.City(),
                        IbgeCode = faker.Random.Number(100000, 999999),
                        StateId = Guid.NewGuid()
                    },
                    new CityDto() {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.City(),
                        IbgeCode = faker.Random.Number(100000, 999999),
                        StateId = Guid.NewGuid()
                    },
                    new CityDto() {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.City(),
                        IbgeCode = faker.Random.Number(100000, 999999),
                        StateId = Guid.NewGuid()
                    }
                }
            );

            _controller = new(serviceMock.Object);

            var result = await _controller.Get();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<CityDto>;
            Assert.NotEmpty(resultValue);
            Assert.True(resultValue.Count == 3);
        }
    }
}