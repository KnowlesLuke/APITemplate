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
    public class AccountsWriteService_UpdateAccount
    {
        // Mock IAccountsWriteService
        private readonly Mock<IAccountsWriteService> _accountsWriteService;

        // Account Update Request
        private readonly AccountPut accountRequest;

        // Account Response
        private readonly AccountResponse accountResponse;

        public AccountsWriteService_UpdateAccount()
        {
            // Setup Mock AccountsWriteService
            _accountsWriteService = new Mock<IAccountsWriteService>();

            // Setup Account Update Request - Arrange
            accountRequest = new AccountPut
            (
                Id: 1,
                Forename: null,
                Surname: "Test Surname",
                Username: "Username",
                Email: "email@email.com",
                RoleId: 0,
                ModifiedBy: "Person One"
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
                Modified: DateTime.Now
            );
        }

        [Fact]
        public async Task UpdateAccountAsync_ValidAccount_ReturnsAccountResponse()
        {
            // Setup UpdateAccountAsync - If accountRequest is passed, return corresponding accountResponse
            _accountsWriteService.Setup(x => x.UpdateAccountAsync(accountRequest.Id, accountRequest)).ReturnsAsync(accountResponse);

            // Act
            var result = await _accountsWriteService.Object.UpdateAccountAsync(accountRequest.Id, accountRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accountResponse.Id, result.Id);
            Assert.Equal(accountResponse.Forename, result.Forename);
            Assert.Equal(accountResponse.Surname, result.Surname);
            Assert.Equal(accountResponse.DisplayName, result.DisplayName);
            Assert.Equal(accountResponse.Username, result.Username);
            Assert.Equal(accountResponse.Email, result.Email);
            Assert.Equal(accountResponse.RoleId, result.RoleId);
            Assert.Equal(accountResponse.Modified, result.Modified);
        }

        [Fact]
        public async Task UpdateAccountAsync_InvalidAccount_ReturnsNull()
        {
            // Setup UpdateAccountAsync - If null is passed, return null
            _accountsWriteService.Setup(x => x.UpdateAccountAsync(accountRequest.Id, null)).ReturnsAsync(() => null);

            // Act
            var result = await _accountsWriteService.Object.UpdateAccountAsync(accountRequest.Id, null);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAccountAsync_IdEquals0_ReturnsNull()
        {
            // Setup UpdateAccountAsync - If 0 is passed for id, return null
            _accountsWriteService.Setup(x => x.UpdateAccountAsync(0, accountRequest)).ReturnsAsync(() => null);

            // Act
            var result = await _accountsWriteService.Object.UpdateAccountAsync(0, accountRequest);

            // Assert
            Assert.Null(result);
        }
    }
}
