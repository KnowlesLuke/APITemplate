using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Mappings;
using Domain.Entities.ApiTemplate.Accounts;
using Infrastructure.Data;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Accounts
{
    public class AccountsWriteService : IAccountsWriteService
    {
        private readonly APITemplateDbContext _context;
        private readonly ILoggingService _loggingService;

        public AccountsWriteService(APITemplateDbContext context, ILoggingService loggingService)
        {
            _context = context;
            _loggingService = loggingService;
        }

        // Create account
        public async Task<AccountResponse> CreateAccountAsync(AccountRequest request)
        {
            try
            {
                // Map request to Account entity using MappingExtension
                Account account = request.Map<AccountRequest, Account>();

                try
                {
                    // Add account to database
                    await _context.Accounts.AddAsync(account);

                    // Save changes
                    await _context.SaveChangesAsync();

                    // Map account to AccountResponse DTO using MappingExtension
                    return account.Map<Account, AccountResponse>();
                }
                catch (Exception ex)
                {
                    // Log error
                    await _loggingService.LogError(
                        "CreateAccountAsync",
                        $"An error occurred while adding account {request} to the database",
                        ex);

                    throw new Exception("An error occurred while adding account to the database", ex);
                }

            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError(
                    "CreateAccountAsync",
                    $"An error occurred while mapping account request to account {request}",
                    ex);

                throw new Exception("An error occurred while creating an account", ex);
            }
        }

        // Update account
        public Task<AccountResponse> UpdateAccountAsync(AccountRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
