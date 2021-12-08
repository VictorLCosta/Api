using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.DTO.User;
using Api.Service.Interfaces;
using Moq;
using Xunit;

namespace Api.Test.Services.UserService
{
    public class WhenExecuteGetAll : UserTest
    {
        private IUserService _userService;
        private Mock<IUserService> _mockUserService;

        [Fact]
        public async Task IsPossibleExecuteGetAll()
        {
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.GetAll()).ReturnsAsync(UserDtoList);
            _userService = _mockUserService.Object;

            var result = await _userService.GetAll();

            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var listResult = new List<UserDto>();
            _mockUserService = new Mock<IUserService>();
            _mockUserService.Setup(x => x.GetAll()).ReturnsAsync(listResult.AsEnumerable());
            _userService = _mockUserService.Object;

            var resultEmpty = await _userService.GetAll();

            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}