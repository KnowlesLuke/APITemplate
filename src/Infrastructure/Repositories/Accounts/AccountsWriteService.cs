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
            // If request is null, throw exception
            if (request == null)
                throw new Exception("Account request is required");

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
                    $"An error occurred while mapping account request to account {request} - {ex.Message}",
                    ex);

                throw new Exception($"An error occurred while creating an account - {ex.Message}", ex);
            }
        }

        // Update account
        public async Task<AccountResponse> UpdateAccountAsync(int accountId, AccountPut updateRequest)
        {
            // If request is null, throw exception
            if (updateRequest == null)
                throw new Exception("Account update request is required");

            // If account id is less than or equal to 0, throw exception
            if (accountId <= 0)
                throw new Exception("Account Id is required");

            try
            {
                // Get current account by id - If account not found, throw exception
                Account existingAccount = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.Id == accountId) ?? throw new Exception("Account not found");

                // Map update request to Account entity using MappingExtension
                Account updatedAccount = updateRequest.Map<AccountPut, Account>();

                // Update account properties
                _context.Entry(existingAccount).State = EntityState.Modified;

                // Call method to update account properties of existing account - only update properties that are not null
                existingAccount.UpdateAccountEntity(updatedAccount);

                try
                {
                    // Save changes
                    await _context.SaveChangesAsync();

                    // Map updated account to AccountResponse DTO using MappingExtension
                    return existingAccount.Map<Account, AccountResponse>();
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
                    $"An error occurred while mapping account update request to account {updateRequest} - {ex.Message}",
                    ex);

                throw new Exception($"An error occurred while updating an account - {ex.Message}", ex);
            }
        }

        // Delete account / Soft delete
        public async Task DeleteAccountAsync(int accountId, string deletedBy)
        {
            // If account id is less than or equal to 0, throw exception
            if (accountId <= 0)
                throw new Exception("Account Id is required");

            // If deleted by is null or empty, throw exception
            if (string.IsNullOrEmpty(deletedBy))
                throw new Exception("Deleted by is required");

            try
            {
                // Get account by id - If account not found, throw exception
                Account? account = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.Id == accountId) ?? throw new Exception("Account not found");

                // Set account properties
                account.Deleted = DateTime.Now;
                account.DeletedBy = deletedBy;

                // Update account properties
                _context.Entry(account).State = EntityState.Modified;

                // Save changes
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError(
                    "DeleteAccountAsync",
                    $"An error occurred while deleting account {accountId} - {ex.Message}",
                    ex);

                throw new Exception($"An error occurred while deleting an account - {ex.Message} ", ex);
            }
        }
    }
}
