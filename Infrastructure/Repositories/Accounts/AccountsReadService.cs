using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Application.Mappings;
using Domain.Entities.ApiTemplate.Accounts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Accounts
{
    public class AccountsReadService : IAccountsReadService
    {
        // Inject DbContext
        private readonly APITemplateDbContext _context;

        // Inject ILoggingService
        private readonly ILoggingService _loggingService;

        // Max accounts to return
        private const int MaxAccounts = 100;

        // Initialise DbContext
        public AccountsReadService(
            APITemplateDbContext context, 
            ILoggingService loggingService)
        {
            _context = context;
            _loggingService = loggingService;
        }

        // Retrieve all accounts from the database - Limited to [MaxAccounts] records
        public async Task<IEnumerable<AccountResponse>> GetAccountsAsync()
        {
            try
            {
                // Get top [MaxAccounts] accounts from the database and order by display name
                List<Account> accounts = await _context.Accounts
                    .OrderBy(a => a.DisplayName)
                    .Take(MaxAccounts)
                    .ToListAsync();

                // Check if accounts is null or empty
                if (accounts == null || accounts.Count == 0)
                {
                    // Return an empty list of AccountResponse DTO
                    return new List<AccountResponse>();
                }

                // Map accounts to AccountResponse DTO using MappingExtension
                return await MapResponse(accounts, "GetAccountsAsync");
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("GetAccountsAsync", "An error occurred while getting accounts", ex);

                throw new Exception("An error occurred while getting accounts", ex);
            }
        }

        // Retrieve an account by ID from the database
        public async Task<AccountResponse?> GetAccountByIdAsync(int accountId)
        {
            try
            {
                // Get account by ID from the database
                Account? account = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.Id == accountId);

                // Check if account is null
                if (account == null)
                    return null;

                try
                {
                    // Map account to AccountResponse DTO using MappingExtension
                    AccountResponse accountResponse = account.Map<Account, AccountResponse>();

                    // Return account response
                    return accountResponse;
                }
                catch (Exception ex)
                {
                    // Log error
                    await _loggingService.LogError(
                        "GetAccountByIdAsync",
                        $"An error occurred while mapping account: ID {accountId} to account response dto", 
                        ex);

                    throw new Exception("An error occurred while mapping account by ID", ex);
                }
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError(
                    "GetAccountByIdAsync", 
                    $"An error occurred while getting account by ID {accountId}", 
                    ex);

                throw new Exception("An error occurred while getting account by ID", ex);
            }
        }

        // Search accounts by display name
        public async Task<IEnumerable<AccountResponse>> SearchAccountsAsync(string searchTerm)
        {
            try
            {
                // Get top [MaxAccounts] accounts from the database and order by display name
                List<Account> accounts = await _context.Accounts
                    .Where(a => a.DisplayName.Contains(searchTerm))
                    .OrderBy(a => a.DisplayName)
                    .Take(MaxAccounts)
                    .ToListAsync();

                // Check if accounts is null or empty
                if (accounts == null || accounts.Count == 0)
                {
                    // Return an empty list of AccountResponse DTO
                    return new List<AccountResponse>();
                }

                // Map accounts to AccountResponse DTO using MappingExtension
                return await MapResponse(accounts, "SearchAccountsAsync");
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError(
                    "SearchAccountsAsync", 
                    $"An error occurred while searching accounts by search term: {searchTerm}", 
                    ex);

                throw new Exception("An error occurred while searching accounts", ex);
            }
        }

        // Mapping Function For Returning AccountResponse Ienumerable DTO
        public async Task<IEnumerable<AccountResponse>> MapResponse(IEnumerable<Account> accounts, string methodAction)
        {
            try
            {
                // Map accounts to AccountResponse DTO using MappingExtension
                IEnumerable<AccountResponse> accountResponses = accounts.MapList<Account, AccountResponse>();

                // Return account responses
                return accountResponses;
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError(
                    methodAction,
                    "An error occurred while mapping accounts to account response dto",
                    ex);

                throw new Exception("An error occurred while mapping accounts", ex);
            }
        }
    }
}
