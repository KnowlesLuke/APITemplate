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

            // Check if Role ID is valid (int field)
            if (accountRequest.RoleId < 1)
                return BadRequest("Invalid Parameters");

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
    }
}
