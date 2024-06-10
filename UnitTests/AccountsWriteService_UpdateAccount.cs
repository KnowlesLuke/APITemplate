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

    }
}
