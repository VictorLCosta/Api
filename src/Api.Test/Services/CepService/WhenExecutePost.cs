using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CepService
{
    public class WhenExecutePost : CepTest
    {
        private ICepService _cepService;
        private Mock<ICepService> _mockCepService;

        [Fact]
        public async Task IsPossibleExecutePost()
        {
            _mockCepService = new Mock<ICepService>();
            _mockCepService.Setup(x => x.Post(CreateCep)).ReturnsAsync(CreateCepResult);
            _cepService = _mockCepService.Object;

            var result = await _cepService.Post(CreateCep);

            Assert.NotNull(result);
            Assert.Equal(CEP, result.CEP);
            Assert.Equal(PublicPlace, result.PublicPlace);
            Assert.Equal(Number, result.Number);
        }
    }
}