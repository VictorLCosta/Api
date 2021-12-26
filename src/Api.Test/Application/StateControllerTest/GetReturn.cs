using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTO.State;
using Api.Service.Interfaces;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test.Application.StateControllerTest
{
    public class GetReturn
    {
        private StateController _controller;

        [Fact]
        public async Task IsPossibleGet()
        {
            Faker faker = new("pt_BR");

            var serviceMock = new Mock<IStateService>();

            var name = faker.Address.State();
            var uf = faker.Address.StateAbbr();
            
            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(
                new StateDto()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    UF = uf
                }
            );

            _controller = new StateController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as StateDto;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, name);
            Assert.Equal(resultValue.UF, uf);
            
        }

        [Fact]
        public async Task MustReturnBadRequest()
        {

            var serviceMock = new Mock<IStateService>();

            _controller = new StateController(serviceMock.Object);

            var result = await _controller.Get(Guid.Empty);
            Assert.True(result is BadRequestObjectResult);

            var resultValue = ((BadRequestObjectResult)result).Value.ToString();
            Assert.True(resultValue.Equals("ID inválido"));

        }

        [Fact]
        public async Task MustReturnNotFound()
        {

            var serviceMock = new Mock<IStateService>();

            _controller = new StateController(serviceMock.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        }
    }
}