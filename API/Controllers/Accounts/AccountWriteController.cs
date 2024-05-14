using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Interfaces.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Accounts
{
    [Route("APITemplate")]
    [ApiController]
    public class AccountWriteController : ControllerBase
    {
        private readonly IAccountsWriteService _accountsWriteService;
        private readonly ILoggingService _loggingService;

        public AccountWriteController(IAccountsWriteService accountsWriteService, ILoggingService loggingService)
        {
            _accountsWriteService = accountsWriteService;
            _loggingService = loggingService;
        }

        [HttpPost("CreateAccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAccountAsync(AccountRequest accountRequest)
        {
            // Validate account
            if (accountRequest == null)
                return BadRequest("Account is required");

            try
            {
                // Create account
                AccountResponse account = await _accountsWriteService.CreateAccountAsync(accountRequest);

                // Check if account is null
                if (account == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating account");

                // Return account
                return CreatedAtAction("CreateAccount", account);
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("CreateAccountAsync", "An error occurred while creating account", ex);

                // Return error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating account");
            }
        }

        [HttpPut("UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAccountAsync(int accountId, AccountRequest accountRequest)
        {
            // Validate account
            if (accountRequest == null)
                return BadRequest("Account is required");

            // Validate account ID
            if (accountId <= 0)
                return BadRequest("Account ID is required");

            try
            {
                // Update account
                AccountResponse account = await _accountsWriteService.UpdateAccountAsync(accountId, accountRequest);

                // Check if account is null
                if (account == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating account");

                // Return account
                return Ok(account);
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("UpdateAccountAsync", "An error occurred while updating account", ex);

                // Return error
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating account");
            }
        }
    }
}
