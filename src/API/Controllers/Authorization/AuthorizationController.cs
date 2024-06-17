using Application.DTOs.Authorization;
using Application.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        // Inject the configuration
        private readonly IConfiguration _config;

        public AuthorizationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("CreateToken")]
        public IActionResult CreateToken(AuthRequest authRequest)
        {
            // Check if the request is valid
            if (authRequest == null)
                return BadRequest();

            // Check the auth header fields


            // Check the hash
            var hash = ""; // Create the hash from the database fields

            //if (!hash.CheckHash(authRequest.SecretKeyHash))
            //    return Unauthorized();

            // If the request is valid, create a token
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthenticationSettings:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Set up claims
            var claims = new Dictionary<string, object>
            {
                [ClaimTypes.Name] = authRequest.Name,
                [ClaimTypes.NameIdentifier] = authRequest.PublicKey,
                [ClaimTypes.Hash] = authRequest.SecretKeyHash
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
