using System;
using System.Threading.Tasks;
using Api.Domain.DTO.City;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CityService
{
    public class WhenExecuteGet : CityTest
    {
        private ICityService _cityService;
        private Mock<ICityService> _mockCityService;

        [Fact]
        public async Task IsPossibleExecuteGet()
        {
            _mockCityService = new();
            _mockCityService.Setup(x => x.Get(Id)).ReturnsAsync(CityDto);

            _cityService = _mockCityService.Object;

            var result = await _cityService.Get(Id);

            Assert.NotNull(result);
            Assert.Equal(result.Name, Name);
            Assert.Equal(result.IbgeCode, IbgeCode);
            Assert.True(result.Id != default(Guid));

            _mockCityService = new();
            _mockCityService.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync((CityDto)null);

            _cityService = _mockCityService.Object;

            result = await _cityService.Get(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}