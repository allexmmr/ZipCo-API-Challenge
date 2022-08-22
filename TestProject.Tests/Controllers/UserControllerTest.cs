using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.WebAPI.Controllers;
using TestProject.WebAPI.Services.Interface;
using TestProject.WebAPI.ViewModels;
using Xunit;

namespace TestProject.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public async Task ListUser_ReturnsUsers()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<UserController>>();
            var mockUserService = new Mock<IUserService>();

            IEnumerable<UserResponse> response = new List<UserResponse>
            {
                new UserResponse
                {
                    User = new User
                    {
                        Name = "Allex Rocha",
                        EmailAddress = "allexmmr@gmail.com",
                        Password = "Izi5XK0sLgpoHc56Nisv",
                        MonthlySalary = 2000,
                        MonthlyExpenses = 1000
                    }
                }
            };

            mockUserService.Setup(q => q.ListAsync()).Returns(Task.FromResult(response));

            var controller = new UserController(mockLogger.Object, mockUserService.Object);

            // Act
            var result = await controller.ListAsync();

            var okObjectResult = result as ObjectResult;

            // Assert
            var actual = (List<UserResponse>)okObjectResult.Value;

            Assert.NotNull(okObjectResult);
            Assert.True(okObjectResult is OkObjectResult);
            Assert.IsType<List<UserResponse>>(okObjectResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
            Assert.True(actual.Any());
        }

        [Fact]
        public async Task CreateUser_ReturnsUser()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<UserController>>();
            var mockUserService = new Mock<IUserService>();

            var request = new UserRequest()
            {
                Name = "Allex Rocha",
                EmailAddress = "allexmmr@gmail.com",
                Password = "Izi5XK0sLgpoHc56Nisv",
                MonthlySalary = 2000,
                MonthlyExpenses = 1000
            };

            var response = new UserResponse
            {
                User = new User()
                {
                    Id = 2,
                    Name = "Allex Rocha",
                    EmailAddress = "allexmmr@gmail.com",
                    Password = "Izi5XK0sLgpoHc56Nisv",
                    MonthlySalary = 2000,
                    MonthlyExpenses = 1000
                },
                Success = true
            };

            mockUserService.Setup(q => q.CreateAsync(request)).Returns(Task.FromResult(response));

            var controller = new UserController(mockLogger.Object, mockUserService.Object);

            // Act
            var result = await controller.CreateAsync(request);

            var okObjectResult = result as ObjectResult;

            // Assert
            var actual = (UserResponse)okObjectResult.Value;

            Assert.NotNull(okObjectResult);
            Assert.True(okObjectResult is OkObjectResult);
            Assert.IsType<UserResponse>(okObjectResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
            Assert.True(actual.Success);
            Assert.Equal("Allex Rocha", actual.User.Name);
        }

        [Fact]
        public async Task GetUser_ReturnsUser()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<UserController>>();
            var mockUserService = new Mock<IUserService>();

            var emailAddress = "allexmmr@gmail.com";

            var response = new UserResponse
            {
                User = new User()
                {
                    Id = 2,
                    Name = "Allex Rocha",
                    EmailAddress = "allexmmr@gmail.com",
                    Password = "Izi5XK0sLgpoHc56Nisv",
                    MonthlySalary = 2000,
                    MonthlyExpenses = 1000
                },
                Success = true
            };

            mockUserService.Setup(q => q.GetAsync(emailAddress)).Returns(Task.FromResult(response));

            var controller = new UserController(mockLogger.Object, mockUserService.Object);

            // Act
            var result = await controller.GetAsync(emailAddress);

            var okObjectResult = result as ObjectResult;

            // Assert
            var actual = (UserResponse)okObjectResult.Value;

            Assert.NotNull(okObjectResult);
            Assert.True(okObjectResult is OkObjectResult);
            Assert.IsType<UserResponse>(okObjectResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
            Assert.True(actual.Success);
            Assert.Equal("Allex Rocha", actual.User.Name);
        }
    }
}