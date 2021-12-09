using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.UserService
{
    public class WhenExecutePut : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _mockUserService;

        [Fact]
        public async Task IsPossibleExecutePut()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.Put(UserDto)).ReturnsAsync(UpdateUserResult);
            _userService = _mockUserService.Object;

            var result = await _userService.Put(UserDto);

            Assert.NotNull(result);
            Assert.Equal(UpdatedName, result.Name);
            Assert.Equal(UpdatedEmail, result.Email);
        }
    }
}