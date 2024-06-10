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
            // Validate Account
            if (accountRequest == null)
                return BadRequest("Account is required");

            try
            {
                // Create Account
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
        public async Task<IActionResult> UpdateAccountAsync(AccountPut accountRequest)
        {
            // Validate Account
            if (accountRequest == null)
                return BadRequest("Account is required");

            // Validate Account Id
            if (accountRequest.Id <= 0)
                return BadRequest("Account Id is required");

            try
            {
                // Update account
                AccountResponse account = await _accountsWriteService.UpdateAccountAsync(accountRequest.Id, accountRequest);

                // Check if return account is null
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

        [HttpDelete("DeleteAccount/{accountId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAccountAsync(int accountId, string deletedBy)
        {
            // Validate Account Id
            if (accountId <= 0)
                return BadRequest("Account Id is required");

            try
            {
                // Delete account
                await _accountsWriteService.DeleteAccountAsync(accountId, deletedBy);

                // Return success
                return Ok("Account deleted successfully");
            }
            catch (Exception ex)
            {
                // Log error
                await _loggingService.LogError("DeleteAccountAsync", $"An error occurred while deleting account - {ex.Message}", ex);

                // Return error
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while deleting account - {ex.Message}");
            }
        }
    }
}
