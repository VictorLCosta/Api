using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CepService
{
    public class WhenExecuteUpdate : CepTest
    {
        private ICepService _cepService;
        private Mock<ICepService> _mockCepService;

        [Fact]
        public async Task IsPossibleExecutePut()
        {
            _mockCepService = new();
            _mockCepService.Setup(x => x.Put(UpdateCep)).ReturnsAsync(UpdateCepResult);
            _cepService = _mockCepService.Object;

            var result = await _cepService.Put(UpdateCep);

            Assert.NotNull(result);
            Assert.Equal(UpdatedCEP, result.CEP);
            Assert.Equal(UpdatedPublicPlace, result.PublicPlace);
            Assert.Equal(UpdatedNumber, result.Number);
        }
    }
}