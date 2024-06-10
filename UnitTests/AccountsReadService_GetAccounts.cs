using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class AccountsReadService_GetAccounts
    {
        // Mock IAccountsReadService
        private readonly Mock<IAccountsReadService> _accountsReadService;

        // Account Response
        private readonly IEnumerable<AccountResponse> _accountsResponse;

        public AccountsReadService_GetAccounts()
        {
            // Setup Mock AccountsReadService
            _accountsReadService = new Mock<IAccountsReadService>();

            // Setup Account Response - Arrange
            _accountsResponse = new List<AccountResponse>
            {
                new
                (
                    Id: 1,
                    Forename: "Test Forename",
                    Surname: "Surname",
                    DisplayName: "Test Forename Surname",
                    Username: "Username",
                    Email: "Email Address",
                    RoleId: 1,
                    Created: DateTime.Now,
                    Modified: DateTime.Now
                )
            };
        }

        [Fact]
        public async Task GetAccountsAsync_ReturnsAccountsResponse()
        {
            // Setup GetAccountsAsync - If called, return accountsResponse
            _accountsReadService.Setup(x => x.GetAccountsAsync()).ReturnsAsync(_accountsResponse);

            // Act
            var result = await _accountsReadService.Object.GetAccountsAsync();

            // Assert
            Assert.NotNull(result);

            Assert.Equal(_accountsResponse, result);
            Assert.IsAssignableFrom<IEnumerable<AccountResponse>>(result);
        }

        [Fact]
        public async Task GetAccountByIdAsync_ValidAccountId_ReturnsAccountResponse()
        {
            // Setup GetAccountByIdAsync - If accountId is passed, return corresponding accountResponse
            _accountsReadService.Setup(x => x.GetAccountByIdAsync(1)).ReturnsAsync(_accountsResponse.FirstOrDefault(x => x.Id == 1));

            // Act
            var result = await _accountsReadService.Object.GetAccountByIdAsync(1);

            // Assert
            Assert.NotNull(result);

            Assert.Equal(_accountsResponse.FirstOrDefault(), result);
            Assert.IsAssignableFrom<AccountResponse>(result);
        }

        [Fact]
        public async Task GetAccountByIdAsync_InvalidAccountId_ReturnsNull()
        {
            // Setup GetAccountByIdAsync - If 0 is passed, return null
            _accountsReadService.Setup(x => x.GetAccountByIdAsync(0)).ReturnsAsync((AccountResponse)null);

            // Act
            var result = await _accountsReadService.Object.GetAccountByIdAsync(0);

            // Assert
            Assert.Null(result);
        }
    }
}
