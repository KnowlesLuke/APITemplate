using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Accounts
{
    [Route("APITemplate")]
    [ApiController]
    public class AccountReadController : ControllerBase
    {
        private readonly IAccountsReadService _accountsReadService;
        private readonly ILoggingService _loggingService;

        public AccountReadController(IAccountsReadService accountsReadService, ILoggingService loggingService)
        {
            _accountsReadService = accountsReadService;
            _loggingService = loggingService;
        }

        [HttpGet("GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountsAsync()
        {
            try
            {
                // Get accounts from the service
                IEnumerable<AccountResponse> accounts = await _accountsReadService.GetAccountsAsync();

                // Return accounts
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("GetAccountsAsync", "An error occurred while getting accounts", ex);

                // Return error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting accounts");
            }
        }

        [HttpGet("GetAccountById/{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountByIdAsync(int accountId)
        {
            try
            {
                // Get account from the service
                AccountResponse? account = await _accountsReadService.GetAccountByIdAsync(accountId);

                // Check if account is null
                if (account == null)
                {
                    // Return not found
                    return NotFound();
                }

                // Return account
                return Ok(account);
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("GetAccountByIdAsync", "An error occurred while getting account by id", ex);

                // Return error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting account by id");
            }
        }

        [HttpGet("SearchAccounts/{searchTerm}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SearchAccounts(string searchTerm)
        {
            try
            {
                // Validate search term
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return BadRequest("Search term is required");

                // Get accounts from the service
                IEnumerable<AccountResponse> accounts = await _accountsReadService.SearchAccountsAsync(searchTerm);

                // Return filtered accounts
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("SearchAccounts", "An error occurred while searching accounts", ex);

                // Return error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching accounts");
            }
        }
    }
}
