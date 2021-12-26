using System;
using System.Threading.Tasks;
using Api.Domain.DTO.State;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.StateService
{
    public class WhenExecuteGet : StateTest
    {
        private IStateService _stateService;
        private Mock<IStateService> _mockStateService;

        [Fact]
        public async Task IsPossibleExecuteGet()
        {
            _mockStateService = new();
            _mockStateService.Setup(x => x.Get(Id)).ReturnsAsync(StateDto);

            _stateService = _mockStateService.Object;

            var result = await _stateService.Get(Id);

            Assert.NotNull(result);
            Assert.Equal(result.UF, UF);
            Assert.Equal(result.Name, Name);

            _mockStateService = new();
            _mockStateService.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync((StateDto)null);

            _stateService = _mockStateService.Object;

            result = await _stateService.Get(Guid.NewGuid());

            Assert.Null(result);
        }
    }
}