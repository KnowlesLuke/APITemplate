using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Accounts.Read
{
    public class GetAccounts
    {
        // Mock IAccountsReadService
        private readonly Mock<IAccountsReadService> _accountsReadService;

        // Accounts Response
        private readonly IEnumerable<AccountResponse> _accountsResponse;

        // Account Response
        private readonly AccountResponse _accountResponse;

        public GetAccounts()
        {
            // Setup Mock AccountsReadService
            _accountsReadService = new Mock<IAccountsReadService>();

            // Setup account response
            _accountResponse = new AccountResponse
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
            );

            // Setup Account Response - Arrange and Add account response to the list
            _accountsResponse = new List<AccountResponse>
            {
                _accountResponse
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

            // Check if the result is equal to the accountResponse
            Assert.Equal(_accountsResponse, result);

            // Check if the result is of type IEnumerable<AccountResponse>
            Assert.IsAssignableFrom<IEnumerable<AccountResponse>>(result);
        }

        [Fact]
        public async Task GetAccountByIdAsync_ValidAccountId_ReturnsAccountResponse()
        {
            // Setup GetAccountByIdAsync - If accountId is passed, return corresponding accountResponse
            _accountsReadService.Setup(x => x.GetAccountByIdAsync(1)).ReturnsAsync(_accountResponse);

            // Act
            var result = await _accountsReadService.Object.GetAccountByIdAsync(1);

            // Assert
            Assert.NotNull(result);

            Assert.Equal(_accountResponse, result);
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
