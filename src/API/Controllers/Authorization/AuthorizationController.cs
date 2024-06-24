using Application.DTOs.Authorization;
using Application.Extensions;
using Application.Interfaces.Common.AppManagement;
using Application.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.Authorization
{
    [Route("APITemplate")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        // Inject the configuration
        private readonly IConfiguration _config;

        // Setup IAppManagementReadService
        private readonly IAppManagementService _appManagementService;

        public AuthorizationController(IConfiguration config, IAppManagementService appManagementService)
        {
            _config = config;
            _appManagementService = appManagementService;
        }

        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken(AuthRequest authRequest)
        {
            // Check if the request is valid
            if (authRequest == null)
                return BadRequest();

            // Check the hash
            AppManagementAuth auth = await _appManagementService.ValidateRequest(authRequest.PublicKey, authRequest.Action);

            // Check if the auth is null
            if (auth == null)
                return Unauthorized();

            // Build the hashed secret key
            string hashBuilder = auth.SecretKey + "_" + auth.PublicKey + "_" + authRequest.Action;

            // Create the hashed key
            string hashedKey = hashBuilder.CreateHash();

            // Check that the secret key matches the hash - Implement the CheckHash extension method
            //if (!hashedKey.CheckHash(authRequest.SecretKeyHash))
            //    return Unauthorized();

            // If the request is valid, setup the security key and credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthenticationSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Set up claims - Seperate for read and write
            var claims = new Dictionary<string, object>
            {
                [ClaimTypes.Name] = authRequest.Name,
                [ClaimTypes.NameIdentifier] = authRequest.PublicKey,
                [ClaimTypes.Sid] = authRequest.SecretKeyHash,
                [ClaimTypes.Role] = auth.CanWrite ? "Write" : "Read"
            };

            // Create Json Web Token Options class
            var token = new SecurityTokenDescriptor
            {
                Issuer = _config["AuthenticationSettings:Issuer"],
                Audience = _config["AuthenticationSettings:Audience"],
                Claims = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = credentials
            };

            // Set up the handler
            JsonWebTokenHandler handler = new()
            {
                SetDefaultTimesOnTokenCreation = false
            };

            // Create the token
            var tokenString = handler.CreateToken(token);

            return Ok(tokenString);
        }
    }
}
