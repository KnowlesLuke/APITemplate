using Application.DTOs.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Models.Common;
using Domain.Entities.ApiTemplate.Accounts;
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
    public class AccountsWriteServiceDeleteAccount
    {
        // Account Details
        private readonly Account _account1;

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

        public AccountsWriteServiceDeleteAccount()
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

            // Set up account details
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

            // Add account to database
            _context.Accounts.Add(_account1);
            _context.SaveChanges();

            #endregion Initialize
        }

        [Fact]
        public void DeleteValidAccount_ReturnsNoException()
        {
            // Act
            var result = _accountsWriteService.DeleteAccountAsync(_account1.Id, _account1.CreatedBy).Exception;

            // Assert - Check if no exception
            Assert.Null(result);

            // Assert - Check if deleted timestamp is not null
            Assert.NotNull(_account1.Deleted);

            // Check if deleted by is the same as created by
            Assert.NotNull(_account1.DeletedBy);
            Assert.Equal(_account1.DeletedBy, _account1.CreatedBy);
        }

        [Fact]
        public void DeleteInvalidAccount_ReturnsException()
        {
            // Act
            var result = _accountsWriteService.DeleteAccountAsync(0, _account1.CreatedBy).Exception;

            // Assert - Check if exception
            Assert.NotNull(result);

            // Check if exception message is correct
            Assert.Equal("Account Id is required", result?.InnerException?.Message);

            // Assert - Check if deleted timestamp and deleted by are null
            Assert.Null(_account1.Deleted);
            Assert.Null(_account1.DeletedBy);
        }

        [Fact]
        public void DeleteAccountWithNullDeletedBy_ReturnsException()
        {
            // Act
            var result = _accountsWriteService.DeleteAccountAsync(_account1.Id, null).Exception;

            // Assert - Check if exception
            Assert.NotNull(result);

            // Check if exception message is correct
            Assert.Equal("Deleted by is required", result?.InnerException?.Message);

            // Assert - Check if deleted timestamp and deleted by are null
            Assert.Null(_account1.Deleted);
            Assert.Null(_account1.DeletedBy);
        }
    }
}
