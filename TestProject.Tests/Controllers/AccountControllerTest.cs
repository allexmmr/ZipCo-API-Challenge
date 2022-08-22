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
    public class AccountControllerTest
    {
        [Fact]
        public async Task ListAccount_ReturnsAcounts()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AccountController>>();
            var mockAccountService = new Mock<IService<AccountResponse, AccountRequest>>();

            IEnumerable<AccountResponse> response = new List<AccountResponse>
            {
                new AccountResponse
                {
                    Account = new Account { AccountNumber = "123412341234" }
                }
            };

            mockAccountService.Setup(q => q.ListAsync()).Returns(Task.FromResult(response));

            var controller = new AccountController(mockLogger.Object, mockAccountService.Object);

            // Act
            var result = await controller.ListAsync();

            var okObjectResult = result as ObjectResult;

            // Assert
            var actual = (List<AccountResponse>)okObjectResult.Value;

            Assert.NotNull(okObjectResult);
            Assert.True(okObjectResult is OkObjectResult);
            Assert.IsType<List<AccountResponse>>(okObjectResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
            Assert.True(actual.Any());
        }

        [Fact]
        public async Task CreateAccount_ReturnsAccount()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AccountController>>();
            var mockAccountService = new Mock<IService<AccountResponse, AccountRequest>>();

            var user = new User()
            {
                Name = "Allex Rocha",
                EmailAddress = "allexmmr@gmail.com",
                Password = "Izi5XK0sLgpoHc56Nisv",
                MonthlySalary = 2000,
                MonthlyExpenses = 1000
            };

            var accountNumber = "123412341234";

            var request = new AccountRequest()
            {
                User = user,
                AccountNumber = accountNumber
            };

            var response = new AccountResponse
            {
                Account = new Account() { User = user, AccountNumber = accountNumber },
                Success = true
            };

            mockAccountService.Setup(q => q.CreateAsync(request)).Returns(Task.FromResult(response));

            var controller = new AccountController(mockLogger.Object, mockAccountService.Object);

            // Act
            var result = await controller.CreateAsync(request);

            var okObjectResult = result as ObjectResult;

            // Assert
            var actual = (AccountResponse)okObjectResult.Value;

            Assert.NotNull(okObjectResult);
            Assert.True(okObjectResult is OkObjectResult);
            Assert.IsType<AccountResponse>(okObjectResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
            Assert.True(actual.Success);
            Assert.Equal(accountNumber, actual.Account.AccountNumber);
        }
    }
}