using System;
using System.Collections.Generic;
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
    public class GetAllReturn
    {
        private StateController _controller;

        [Fact]
        public async Task IsPossibleGetAll()
        {
            Faker faker = new("pt_BR");

            var serviceMock = new Mock<IStateService>();

            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<StateDto>() {
                    new StateDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.State(),
                        UF = faker.Address.StateAbbr()
                    },
                    new StateDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.State(),
                        UF = faker.Address.StateAbbr()
                    },
                    new StateDto()
                    {
                        Id = Guid.NewGuid(),
                        Name = faker.Address.State(),
                        UF = faker.Address.StateAbbr()
                    }
                }
            );

            _controller = new StateController(serviceMock.Object);

            var result = await _controller.Get();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<StateDto>;
            Assert.NotEmpty(resultValue);
            Assert.True(resultValue.Count == 3);

        }
    }
}