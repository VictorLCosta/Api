using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CityService
{
    public class WhenExecutePost : CityTest
    {
        private ICityService _cityService;
        private Mock<ICityService> _mockCityService;

        [Fact]
        public async Task IsPossibleExecutePost()
        {
            _mockCityService = new();
            _mockCityService.Setup(x => x.Post(CreateCity)).ReturnsAsync(CreateCityResult);

            _cityService = _mockCityService.Object;

            var result = await _cityService.Post(CreateCity);

            Assert.NotNull(result);
            Assert.Equal(result.Name, Name);
            Assert.Equal(result.IbgeCode, IbgeCode);

        }
    }
}