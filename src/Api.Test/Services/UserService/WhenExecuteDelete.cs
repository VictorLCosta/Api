using System;
using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.UserService
{
    public class WhenExecuteDelete : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _mockUserService;

        [Fact]
        public async Task IsPossibleExecuteDelete()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userService = _mockUserService.Object;

            var result = await _userService.Delete(Id);

            Assert.True(result);

            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _userService = _mockUserService.Object;

            result = await _userService.Delete(Guid.NewGuid());

            Assert.False(result);
        }
    }
}