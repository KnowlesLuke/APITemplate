using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Domain.Entities.ApiTemplate.Accounts;
using Infrastructure.Data;
using Infrastructure.Repositories.Common;
using Infrastructure.Services.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace IntegrationTests.Accounts.Read
{
    public class AccountsReadServiceGetAccounts
    {
        private readonly Account _account1;
        private readonly Account _account2;

        // Application Details
        private readonly IOptions<AppDetails> _applicationDetails;

        // ILogging Service
        private readonly ILoggingService _loggingService;

        // DbContext Options Builder
        private readonly DbContextOptions<APITemplateDbContext> _dbOptions;

        // DbContext
        private readonly APITemplateDbContext _context;

        // Account Service
        private readonly AccountsReadService _accountsReadService;

        public AccountsReadServiceGetAccounts()
        {
            #region Initialize

            // Set up test application details
            _applicationDetails = Options.Create(new AppDetails { Name = "APITemplateRead" });

            // Set up test logging service
            _loggingService = new LoggingService(new ApplicationManagementDbContext(new DbContextOptions<ApplicationManagementDbContext>()), _applicationDetails);

            // Set up database options
            _dbOptions = new DbContextOptionsBuilder<APITemplateDbContext>()
                .UseInMemoryDatabase("APITemplateReadTest", new InMemoryDatabaseRoot())
                .EnableSensitiveDataLogging()
                .Options;

            // Set up database context
            _context = new APITemplateDbContext(_dbOptions);

            #region Setup & Seed Data

            // Create account
            _account1 = new()
            {
                Forename = "John", Surname = "Doe", Username = "John.Doe",
                Email = "email@email.com", CreatedBy = "Seed", Version = ""u8.ToArray()
            };

            _account1.SetDisplayName();

            // Create account
            _account2 = new()
            {
                Forename = "Edgar", Surname = "Freezone", Username = "Edgar.Freezone",
                Email = "email@email.com", CreatedBy = "Seed", Version = ""u8.ToArray()
            };

            _account2.SetDisplayName();

            // Add accounts to database
            _context.Accounts.Add(_account1);
            _context.Accounts.Add(_account2);

            _context.SaveChanges();

            #endregion

            // Set up accounts read service
            _accountsReadService = new(_context, _loggingService);

            #endregion
        }

        [Fact]
        public async Task GetAccounts_Success()
        {
            // Act
            var accounts = await _accountsReadService.GetAccountsAsync();

            // Assert
            Assert.NotNull(accounts);

            // Check that there are 2 accounts
            Assert.Equal(2, accounts.Count());

            // Check that the accounts have the correct Forenames
            Assert.Contains(accounts, x => x.Forename == "John");
            Assert.Contains(accounts, x => x.Forename == "Edgar");

            // Check that the accounts have the correct Display Names
            Assert.Contains(accounts, x => x.DisplayName == "John Doe");
            Assert.Contains(accounts, x => x.DisplayName == "Edgar Freezone");
        }

        [Fact]
        public async Task GetAccountById_Success()
        {
            // Act
            var account = await _accountsReadService.GetAccountByIdAsync(1);

            // Assert
            Assert.NotNull(account);

            // Check that the account has the correct Id
            Assert.Equal(_account1.Id, account.Id);

            // Check that the account has the correct details
            Assert.Equal("John", account.Forename);
            Assert.Equal("Doe", account.Surname);
            Assert.Equal("John.Doe", account.Username);
            Assert.Equal("John Doe", account.DisplayName);
            Assert.Equal("email@email.com", account.Email);
        }

        [Fact]
        public async Task GetAccountById_Fail()
        {
            // Act
            var account = await _accountsReadService.GetAccountByIdAsync(3);

            // Assert
            Assert.Null(account);
        }

        [Fact]
        public async Task SearchAccountByName_Success()
        {
            // Act
            var account = await _accountsReadService.SearchAccountsAsync("John");

            // Assert
            Assert.NotNull(account);

            // Check that there is 1 account
            Assert.Single(account);

            // Check that the account has the correct Forename
            Assert.Contains(account, x => x.Forename == "John");
        }

        [Fact]
        public async Task SearchAccountByName_Fail()
        {
            // Act
            var account = await _accountsReadService.SearchAccountsAsync("Jane");

            // Assert
            Assert.NotNull(account);

            // Check that there are no accounts
            Assert.Empty(account);
        }
    }
}
