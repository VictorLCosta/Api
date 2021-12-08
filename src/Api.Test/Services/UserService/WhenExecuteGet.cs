using System;
using System.Threading.Tasks;
using Api.Domain.DTO.User;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.UserService
{
    public class WhenExecuteGet : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _mockUserService;

        [Fact]
        public async Task IsPossibleExecuteGet()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.Get(Id)).ReturnsAsync(UserDto);
            _userService = _mockUserService.Object;

            var result = await _userService.Get(Id);

            Assert.NotNull(result);
            Assert.True(result.Id == Id);
            Assert.Equal(result.Name, Name);

            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _userService = _mockUserService.Object;

            var result2 = await _userService.Get(Id);

            Assert.Null(result2);
        }
    }
}