using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Data.Entities;
using TestProject.Data.Repositories.Interfaces;
using TestProject.WebAPI.Services;
using TestProject.WebAPI.ViewModels;
using Xunit;

namespace TestProject.Tests.Services
{
    public class AccountServiceTest
    {
        private readonly AccountService _accountService;

        public AccountServiceTest()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<AccountService>>();
            var mockAccountRepository = new Mock<IRepository<Account>>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockConfiguration = new Mock<IConfiguration>();
            _accountService = new AccountService(mockLogger.Object, mockAccountRepository.Object, mockUserRepository.Object, mockConfiguration.Object);
        }

        [Fact]
        public async Task ListAccounts_CheckIfAny()
        {
            // Act
            var actual = await _accountService.ListAsync();

            // Assert
            Assert.NotNull(actual);
            Assert.IsAssignableFrom<IEnumerable<AccountResponse>>(actual);
        }
    }
}