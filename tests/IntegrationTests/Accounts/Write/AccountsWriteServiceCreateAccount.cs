using Application.DTOs.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Infrastructure.Data;
using Infrastructure.Repositories.Accounts;
using Infrastructure.Repositories.Common;
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
    public class AccountsWriteServiceCreateAccount
    {
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

        // Account Request
        private readonly AccountRequest _accountRequest;

        public AccountsWriteServiceCreateAccount()
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

            // Set up account request
            _accountRequest = new("Ian", "Flemming", "TMBC\\Ian.Flemming", "ian.flemming@tameside.gov.uk", 1, "Seed");

            #endregion
        }

        [Fact]
        public async Task CreateAccount()
        {
            // Act
            AccountResponse account = await _accountsWriteService.CreateAccountAsync(_accountRequest);

            // Assert
            Assert.NotNull(account);

            // Check account details
            Assert.Equal(1, account.Id);
            Assert.Equal("Ian", account.Forename);
            Assert.Equal("Flemming", account.Surname);
            Assert.Equal("TMBC\\Ian.Flemming", account.Username);
            Assert.Equal("ian.flemming@tameside.gov.uk", account.Email);
        }
    }
}
