using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Domain.Entities.ApiTemplate.Accounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Accounts.Write
{
    public class DeleteAccount
    {
        // Mock IAccountsWriteService
        private readonly Mock<IAccountsWriteService> _accountsWriteService;

        // Account to update
        private readonly Account _account;

        // Account to not update
        private readonly Account _accountNotToUpdate;


        public DeleteAccount()
        {
            // Setup Mock AccountsWriteService
            _accountsWriteService = new Mock<IAccountsWriteService>();

            // Setup Account - Arrange
            _account = new Account
            {
                Id = 1,
                Forename = "Test Forename",
                Surname = "Test Surname",
                Username = "Username",
                Email = "Email",
                RoleId = 1,
                Created = DateTime.Now,
                CreatedBy = "James Doe",
                Deleted = DateTime.Now,
                DeletedBy = "James Doe"
            };

            // Setup Account to not update - Arrange
            _accountNotToUpdate = new Account
            {
                Id = 2,
                Forename = "Forename",
                Surname = "Surname",
                Username = "Username1",
                Email = "Email2",
                Created = DateTime.Now,
                CreatedBy = "Harald Doe"
            };
        }

        [Fact]
        public async Task DeleteAccountAsync_ValidAccount_UpdatesRecord()
        {
            // Setup DeleteAccountAsync - If accountRequest is passed, return corresponding accountResponse
            _accountsWriteService.Setup(x => x.DeleteAccountAsync(1, _account.DeletedBy));

            // Act
            await _accountsWriteService.Object.DeleteAccountAsync(1, _account.DeletedBy);

            // Assert
            _accountsWriteService.Verify(x => x.DeleteAccountAsync(1, _account.DeletedBy), Times.Once);

            // Check deleted by field
            Assert.Equal("James Doe", _account.DeletedBy);

            // Check deleted field
            Assert.IsAssignableFrom<DateTime>(_account.Deleted);
        }

        [Fact]
        public async Task DeleteAccountAsync_InvalidAccount_DoesNotUpdate()
        {
            // Setup DeleteAccountAsync - If accountRequest is passed, return corresponding accountResponse
            _accountsWriteService.Setup(x => x.DeleteAccountAsync(0, ""));

            // Act
            await _accountsWriteService.Object.DeleteAccountAsync(0, "");

            // Assert
            Assert.Null(_accountNotToUpdate.Deleted);
            Assert.Null(_accountNotToUpdate.DeletedBy);
        }
    }
}
