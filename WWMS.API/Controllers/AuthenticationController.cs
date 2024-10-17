using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Users;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IUserService userService,
            IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        #region Login
        /// <summary>
        /// Log into system using username and password
        /// </summary>    
        /// <remarks>
        /// Sample request:  
        /// 
        ///     {
        ///       "username": "admin",
        ///       "password": "admin"
        ///     }   
        ///         
        /// </remarks>
        /// <returns>Json Web Token with User Role</returns>
        /// <response code="200">Return home screen if the access is successful</response>
        /// <response code="400">If the account is null</response>
        /// <response code="500">Internal Server</response>
        [HttpPost("sign-in")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Boolean), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoginAsync([FromBody] UserSignInRequest userSignInRequest)
        {
            try
            {
                var result = await _userService.LoginAsync(
                    userSignInRequest.Username
                    , userSignInRequest.Password);

                if (result == null) return NotFound(new
                {
                    ErrorMessage = "Invalid UserName or Password"
                });

                if (result.Status.Equals("Active"))
                {
                    var accessToken = GenerateAccessToken(result);
                    return Ok(new { AccessToken = accessToken, userInfo = result });
                }

                return BadRequest(new
                {
                    ErrorMessage = "This account has been deactivated. Please contact Admin for further information!"
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Reset Password
        /// <summary>
        /// Log into system using username and password
        /// </summary>    
        /// <remarks>
        /// Sample request:  
        /// 
        ///     {
        ///       "username": "staff4",
        ///       "password": "pJ#ns$9SD@C^",
        ///       "confirmPassword": "pJ#ns$9SD@C^",
        ///       "newPassword": "staff"
        ///     }   
        ///         
        /// </remarks>
        /// <returns>Json Web Token with User Role</returns>
        /// <response code="200">Return home screen if the access is successful</response>
        /// <response code="400">If the account is null</response>
        /// <response code="500">Internal Server</response>
        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Boolean), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
        {
            try
            {
                await _userService.ResetPasswordAsync(request);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }
        #endregion

        #region Generate Access Token
        private string GenerateAccessToken(GetUserResponse user)
        {
            if (user != null)
            {
                List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Role", user.Role),
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.Username)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Key").Value!));

                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                            claims: claims,
                            expires: DateTime.UtcNow.AddHours(1),
                            signingCredentials: credentials
                    );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }

            return string.Empty;
        }
        #endregion
    }
}
