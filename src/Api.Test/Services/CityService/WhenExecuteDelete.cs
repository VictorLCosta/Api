using System;
using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CityService
{
    public class WhenExecuteDelete : CityTest
    {
        private ICityService _cityService;
        private Mock<ICityService> _mockCityService;

        [Fact]
        public async Task IsPossibleExecuteDelete()
        {
            _mockCityService = new();
            _mockCityService.Setup(x => x.Delete(Id)).ReturnsAsync(true);

            _cityService = _mockCityService.Object;

            var result = await _cityService.Delete(Id);

            Assert.True(result);

            _mockCityService = new();
            _mockCityService.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _cityService = _mockCityService.Object;

            result = await _cityService.Delete(Id);

            Assert.False(result);
        }
    }
}