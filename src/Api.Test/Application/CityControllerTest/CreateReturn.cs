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
    public class CreateReturn
    {
        private CityController _controller;

        [Fact]
        public async Task IsPossibleCreate()
        {
            Faker faker = new("pt_BR");

            var serviceMock = new Mock<ICityService>();
            
            var ibgeCode = faker.Random.Number(100000, 999999);
            var name = faker.Address.City();

            serviceMock.Setup(x => x.Post(It.IsAny<CreateCityDto>())).ReturnsAsync
            (
                new CreateCityResultDto
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    IbgeCode = ibgeCode,
                    CreatedAt = DateTime.UtcNow,
                    StateId = Guid.NewGuid()
                }
            );

            _controller = new CityController(serviceMock.Object);

            Mock<IUrlHelper> url = new();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");

            _controller.Url = url.Object;

            var cityDto = new CreateCityDto() 
            {
                Name = name,
                IbgeCode = ibgeCode,
                StateId = Guid.NewGuid()
            };

            var result = await _controller.Post(cityDto);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CreateCityResultDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, cityDto.Name);
            Assert.Equal(resultValue.IbgeCode, cityDto.IbgeCode);
        }
    }
}