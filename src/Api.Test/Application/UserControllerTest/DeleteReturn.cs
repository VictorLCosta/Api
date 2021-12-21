using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test.Application.UserControllerTest
{
    public class DeleteReturn
    {
        private UsersController _controller;

        [Fact]
        public async Task IsPossibleDelete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean) resultValue);
        }

        [Fact]
        public async Task MustReturnBadRequest()
        {
            var serviceMock = new Mock<IUserService>();

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Delete(Guid.Empty);
            Assert.True(result is BadRequestObjectResult);

            var resultValue = ((BadRequestObjectResult)result).Value;
            Assert.NotNull(resultValue);
        }
    }
}