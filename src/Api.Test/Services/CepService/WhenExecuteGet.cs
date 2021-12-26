using System;
using System.Threading.Tasks;
using Api.Domain.DTO.Cep;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.CepService
{
    public class WhenExecuteGet : CepTest
    {
        private ICepService _cepService;
        private Mock<ICepService> _mockCepService;

        [Fact]
        public async Task IsPossibleExecuteGet()
        {
            _mockCepService = new();
            _mockCepService.Setup(x => x.Get(Id)).ReturnsAsync(CepDto);

            _cepService = _mockCepService.Object;

            var result = await _cepService.Get(Id);

            Assert.NotNull(result);
            Assert.Equal(result.CEP, CEP);
            Assert.Equal(result.PublicPlace, PublicPlace);
            Assert.Equal(result.Number, Number);

            _mockCepService = new();
            _mockCepService.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));

            _cepService = _mockCepService.Object;

            result = await _cepService.Get(Guid.NewGuid());

            Assert.Null(result);
           
        }
    }
}