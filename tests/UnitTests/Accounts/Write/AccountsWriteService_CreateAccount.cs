using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Accounts.Write
{
    public class AccountsWriteService_CreateAccount
    {
        // Mock IAccountsWriteService
        private readonly Mock<IAccountsWriteService> _accountsWriteService;

        // Account Request
        private readonly AccountRequest accountRequest;

        // Account Response
        private readonly AccountResponse accountResponse;

        public AccountsWriteService_CreateAccount()
        {
            // Setup Mock AccountsWriteService
            _accountsWriteService = new Mock<IAccountsWriteService>();

            // Setup Account Request - Arrange
            accountRequest = new AccountRequest
            (
                Forename: "Test Forename",
                Surname: "Test Surname",
                Username: "Username",
                Email: "Email",
                RoleId: 1,
                CreatedBy: "James Doe"
            );

            // Setup Account Response - Arrange
            accountResponse = new AccountResponse
            (
                Id: 1,
                Forename: "Test Forename",
                Surname: "Test Surname",
                DisplayName: "Test Forename Test Surname",
                Username: "Username",
                Email: "Email",
                RoleId: 1,
                Created: DateTime.Now,
                Modified: null
            );
        }

        [Fact]
        public async Task CreateAccountAsync_ValidAccount_ReturnsAccountResponse()
        {
            // Setup CreateAccountAsync - If accountRequest is passed, return corresponding accountResponse
            _accountsWriteService.Setup(x => x.CreateAccountAsync(accountRequest)).ReturnsAsync(accountResponse);

            // Act
            var result = await _accountsWriteService.Object.CreateAccountAsync(accountRequest);

            // Assert
            Assert.NotNull(result);

            // Verify CreateAccountAsync is called only once
            _accountsWriteService.Verify(x => x.CreateAccountAsync(accountRequest), Times.Once);

            // Ensure Id is not 0
            Assert.NotEqual(0, result.Id);

            // Ensure values are equal
            Assert.Equal(accountResponse.Forename, result.Forename);
            Assert.Equal(accountResponse.Surname, result.Surname);
            Assert.Equal(accountResponse.DisplayName, result.DisplayName);
            Assert.Equal(accountResponse.Username, result.Username);
            Assert.Equal(accountResponse.Email, result.Email);
            Assert.Equal(accountResponse.RoleId, result.RoleId);
            Assert.Equal(accountResponse.Created, result.Created);
        }

        [Fact]
        public async Task CreateAccountAsync_NullRequest_ReturnsNullResult()
        {
            // Setup CreateAccountAsync - If null is passed, return null
            _accountsWriteService.Setup(x => x.CreateAccountAsync(null)).ReturnsAsync((AccountResponse)null);

            // Act
            var result = await _accountsWriteService.Object.CreateAccountAsync(null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAccountAsync_InvalidRequest_ReturnsNullResult()
        {
            // Setup CreateAccountAsync - If invalid accountRequest is passed, return null
            _accountsWriteService.Setup(x => x.CreateAccountAsync(It.IsAny<AccountRequest>())).ReturnsAsync((AccountResponse)null);

            // Act
            var result = await _accountsWriteService.Object.CreateAccountAsync(It.IsAny<AccountRequest>());

            // Assert
            Assert.Null(result);
        }
    }
}
