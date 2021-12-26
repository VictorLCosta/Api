using System.Linq;
using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CityService
{
    public class WhenExecuteGetAll : CityTest
    {
        private ICityService _cityService;
        private Mock<ICityService> _mockCityService;

        [Fact]
        public async Task IsPossibleExecutePut()
        {
            _mockCityService = new();
            _mockCityService.Setup(x => x.GetAll()).ReturnsAsync(CityList);

            _cityService = _mockCityService.Object;

            var result = await _cityService.GetAll();

            Assert.NotEmpty(result);
            Assert.True(result.Count() == 10);
        }
    }
}