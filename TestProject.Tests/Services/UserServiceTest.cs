using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Data.Repositories.Interfaces;
using TestProject.WebAPI.Services;
using TestProject.WebAPI.ViewModels;
using Xunit;

namespace TestProject.Tests.Services
{
    public class UserServiceTest
    {
        private readonly UserService _userService;

        public UserServiceTest()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<UserService>>();
            var mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(mockLogger.Object, mockUserRepository.Object);
        }

        [Fact]
        public async Task ListUsers_CheckIfAny()
        {
            // Act
            var actual = await _userService.ListAsync();

            // Assert
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<IEnumerable<UserResponse>>(actual);
        }
    }
}