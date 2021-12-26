using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CityService
{
    public class WhenExecutePut : CityTest
    {
        private ICityService _cityService;
        private Mock<ICityService> _mockCityService;

        [Fact]
        public async Task IsPossibleExecutePut()
        {
            _mockCityService = new();
            _mockCityService.Setup(x => x.Put(UpdateCity)).ReturnsAsync(UpdateCityResult);

            _cityService = _mockCityService.Object;

            var result = await _cityService.Put(UpdateCity);

            Assert.NotNull(result);
            Assert.Equal(result.Name, UpdatedName);
            Assert.Equal(result.IbgeCode, UpdatedIbgeCode);
        }
    }
}