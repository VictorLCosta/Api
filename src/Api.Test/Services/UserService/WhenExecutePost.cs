using System.Threading.Tasks;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.UserService
{
    public class WhenExecutePost : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _mockUserService;

        [Fact]
        public async Task IsPossibleExecutePost()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.Post(UserDto)).ReturnsAsync(CreateUserResult);
            _userService = _mockUserService.Object;

            var result = await _userService.Post(UserDto);

            Assert.NotNull(result);
            Assert.Equal(Name, result.Name);
            Assert.Equal(Email, result.Email);
        }
    }
}