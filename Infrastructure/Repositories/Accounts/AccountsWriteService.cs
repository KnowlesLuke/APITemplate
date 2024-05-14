using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Mappings;
using Domain.Entities.ApiTemplate.Accounts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        public async Task<AccountResponse> UpdateAccountAsync(int accountId, AccountRequest updateRequest)
        {
            try
            {
                // Get current account by id - If account not found, throw exception
                Account existingAccount = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.Id == accountId) ?? throw new Exception("Account not found");

                // Map update request to Account entity using MappingExtension
                Account updatedAccount = updateRequest.Map<AccountRequest, Account>();

                // Update account properties
                _context.Entry(existingAccount).CurrentValues.SetValues(updatedAccount);

                try
                {
                    // Save changes
                    await _context.SaveChangesAsync();

                    // Map updated account to AccountResponse DTO using MappingExtension
                    return updatedAccount.Map<Account, AccountResponse>();
                }
                catch (Exception ex)
                {
                    // Log error
                    await _loggingService.LogError(
                        "UpdateAccountAsync",
                        $"An error occurred while updating account {accountId} in the database",
                        ex);

                    throw new Exception("An error occurred while updating account in the database", ex);
                }
            } 
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError(
                    "UpdateAccountAsync",
                    $"An error occurred while mapping account update request to account {updateRequest}",
                    ex);

                throw new Exception("An error occurred while updating an account", ex);
            }
        }
    }
}
