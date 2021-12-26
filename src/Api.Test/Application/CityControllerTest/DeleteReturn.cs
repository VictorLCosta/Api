using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test.Application.CityControllerTest
{
    public class DeleteReturn
    {
        private CityController _controller;
        
        [Fact]
        public async Task IsPossibleDelete()
        {
            var serviceMock = new Mock<ICityService>();

            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            _controller = new(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean) resultValue);
        }

        [Fact]
        public async Task MustReturnBadRequest()
        {
            var serviceMock = new Mock<ICityService>();

            _controller = new(serviceMock.Object);

            var result = await _controller.Delete(Guid.Empty);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}