using System;
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
    public class UpdateReturn
    {
         private CityController _controller;

        [Fact]
        public async Task IsPossibleUpdate()
        {
            Faker faker = new("pt_BR");

            var serviceMock = new Mock<ICityService>();

            var ibgeCode = faker.Random.Number(100000, 999999);
            var name = faker.Address.City();

            serviceMock.Setup(x => x.Put(It.IsAny<UpdateCityDto>())).ReturnsAsync(
                new UpdateCityResultDto() {
                    Id = Guid.NewGuid(),
                    Name = name,
                    IbgeCode = ibgeCode,
                    StateId = Guid.NewGuid()
                }
            );

            _controller = new(serviceMock.Object);

            var cityDto = new UpdateCityDto()
            {
                Id = Guid.NewGuid(),
                Name = name, 
                IbgeCode = ibgeCode,
                StateId = Guid.NewGuid()
            };

            var result = await _controller.Put(cityDto);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UpdateCityResultDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, name);
            Assert.Equal(resultValue.IbgeCode, ibgeCode);
        }

        [Fact]
        public async Task MustReturnUnprocessableEntity()
        {
            var serviceMock = new Mock<ICityService>();
            
            _controller = new(serviceMock.Object);

            var updateCity = new UpdateCityDto()
            {
                Id = Guid.NewGuid(),
                StateId = Guid.NewGuid(),
                IbgeCode = -1
            };

            var result = await _controller.Put(updateCity);
            Assert.True(result is UnprocessableEntityObjectResult);

        }
    }
}