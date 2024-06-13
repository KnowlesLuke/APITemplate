using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Domain.Entities.ApiTemplate.Accounts;
using Infrastructure.Data;
using Infrastructure.Repositories.Accounts;
using Infrastructure.Repositories.Common;
using Infrastructure.Services.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests.Accounts.Write
{
    public class AccountsWriteServiceUpdateAccount
    {
        // Account Details
        private readonly Account _account1;

        // Account Put Request
        private readonly AccountPut _accountPutRequest;

        // Application Details
        private readonly IOptions<AppDetails> _applicationDetails;

        // ILogging Service
        private readonly ILoggingService _loggingService;

        // DbContext Options Builder
        private readonly DbContextOptions<APITemplateDbContext> _dbOptions;

        // DbContext
        private readonly APITemplateDbContext _context;

        // Account Service
        private readonly AccountsWriteService _accountsWriteService;

        public AccountsWriteServiceUpdateAccount()
        {
            #region Initialize

            // Set up test application details
            _applicationDetails = Options.Create(new AppDetails { Name = "APITemplateWrite" });

            // Set up test logging service
            _loggingService = new LoggingService(new ApplicationManagementDbContext(new DbContextOptions<ApplicationManagementDbContext>()), _applicationDetails);

            // Set up database options
            _dbOptions = new DbContextOptionsBuilder<APITemplateDbContext>()
                .UseInMemoryDatabase("APITemplateWriteTest", new InMemoryDatabaseRoot())
                .EnableSensitiveDataLogging()
                .Options;

            // Set up database context
            _context = new APITemplateDbContext(_dbOptions);

            // Set up account service
            _accountsWriteService = new AccountsWriteService(_context, _loggingService);

            // Set up account
            _account1 = new()
            {
                Id = 1,
                Forename = "John",
                Surname = "Doe",
                Username = "John.Doe",
                Email = "john@doe.com",
                RoleId = 1,
                CreatedBy = "Seed",
                Version = Guid.NewGuid().ToByteArray()
            };

            // Set up account put request
            _accountPutRequest = new(1, "James", null, "James.Doe", "james@doe.com", 0, "L.K");

            #endregion
        }

        [Fact]
        public async Task UpdateValidAccount_ReturnsResponse_Success()
        {
            // Arrange - Add account to database
            await _context.Accounts.AddAsync(_account1);
            await _context.SaveChangesAsync();

            // Act - Update account
            AccountResponse account = await _accountsWriteService.UpdateAccountAsync(_accountPutRequest.Id, _accountPutRequest);

            // Assert - Check response is not null
            Assert.NotNull(account);

            // Check account details
            Assert.Equal(1, account.Id);
            Assert.Equal("James", account.Forename);
            Assert.Equal("Doe", account.Surname);
            Assert.Equal("James.Doe", account.Username);
        }

        [Fact]
        public async Task UpdateAccountWithNullValues_ReturnsException_Fail()
        {
            // Arrange - Add account to database
            await _context.Accounts.AddAsync(_account1);
            await _context.SaveChangesAsync();

            // Act - Update account
            var account = _accountsWriteService.UpdateAccountAsync(_accountPutRequest.Id, null).Exception;

            // Assert - Has Exception
            Assert.NotNull(account);

            // Check Exception Message
            Assert.Equal("Account update request is required", account.InnerException.Message);
        }

        [Fact]
        public async Task UpdateAccountWithInvalidId_ReturnsException_Fail()
        {
            // Arrange - Add account to database
            await _context.Accounts.AddAsync(_account1);
            await _context.SaveChangesAsync();

            // Act - Update account
            var account = _accountsWriteService.UpdateAccountAsync(0, _accountPutRequest).Exception;

            // Assert - Has Exception
            Assert.NotNull(account);

            // Check Exception Message
            Assert.Equal("Account Id is required", account.InnerException.Message);
        }
    }
}