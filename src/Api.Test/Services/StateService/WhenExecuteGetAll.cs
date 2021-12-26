using System.Linq;
using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.StateService
{
    public class WhenExecuteGetAll : StateTest
    {
        private IStateService _stateService;
        private Mock<IStateService> _mockStateService;

        [Fact]
        public async Task IsPossibleExecuteGetAll()
        {
            _mockStateService = new();
            _mockStateService.Setup(x => x.GetAll()).ReturnsAsync(StateList);

            _stateService = _mockStateService.Object;

            var result = await _stateService.GetAll();

            Assert.NotEmpty(result);
            Assert.True(result.Count() == 10);
        }
    }
}