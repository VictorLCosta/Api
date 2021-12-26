using System.Threading.Tasks;
using Api.Domain.DTO.Cep;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CepService
{
    public class WhenExecuteGetByCep : CepTest
    {
        private ICepService _cepService;
        private Mock<ICepService> _mockCepService;

        [Fact]
        public async Task IsPossibleExecuteGetByCep()
        {
            _mockCepService = new();
            _mockCepService.Setup(x => x.Get(CEP)).ReturnsAsync(CepDto);

            _cepService = _mockCepService.Object;

            var result = await _cepService.Get(CEP);

            Assert.NotNull(result);
            Assert.Equal(result.CEP, CEP);
            Assert.Equal(result.PublicPlace, PublicPlace);
            Assert.Equal(result.Number, Number);

            _mockCepService = new();
            _mockCepService.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult((CepDto)null));

            _cepService = _mockCepService.Object;

            result = await _cepService.Get(CEP);

            Assert.Null(result);
        }
    }
}