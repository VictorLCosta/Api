using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTO.City;
using Api.Domain.DTO.State;
using Api.Service.Interfaces;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test.Application.CityControllerTest
{
    public class GetReturn
    {
        private CityController _controller;

        [Fact]
        public async Task IsPossibleGet()
        {
            Faker faker = new("pt_BR");

            var serviceMock = new Mock<ICityService>();

            var ibgeCode = faker.Random.Number(100000, 999999);
            var name = faker.Address.City();

            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CityDto() {
                    Id = Guid.NewGuid(),
                    IbgeCode = ibgeCode,
                    Name = name,
                    StateId = Guid.NewGuid(),
                }
            );

            _controller = new(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CityDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, name);
            Assert.Equal(resultValue.IbgeCode, ibgeCode);
        }

        [Fact]
        public async Task MustReturnBadRequest()
        {

            var serviceMock = new Mock<ICityService>();

            _controller = new CityController(serviceMock.Object);

            var result = await _controller.Get(Guid.Empty);
            Assert.True(result is BadRequestObjectResult);

            var resultValue = ((BadRequestObjectResult)result).Value.ToString();
            Assert.True(resultValue.Equals("ID inválido"));

        }

        [Fact]
        public async Task MustReturnNotFound()
        {

            var serviceMock = new Mock<ICityService>();

            _controller = new CityController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        }
    }
}