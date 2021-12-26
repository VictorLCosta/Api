using System;
using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CepService
{
    public class WhenExecuteDelete : CepTest
    {
        private ICepService _cepService;
        private Mock<ICepService> _mockCepService;

        [Fact]
        public async Task IsPossibleExecuteDelete()
        {
            _mockCepService = new();
            _mockCepService.Setup(x => x.Delete(Id)).ReturnsAsync(true);

            _cepService = _mockCepService.Object;

            var result = await _cepService.Delete(Id);
            Assert.True(result);

            _mockCepService = new();
            _mockCepService.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _cepService = _mockCepService.Object;

            result = await _cepService.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}