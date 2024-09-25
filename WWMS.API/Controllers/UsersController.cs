using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Users;

namespace WWMS.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(
            ILogger<UsersController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        #region Create User
        /// <summary>
        /// Add an user in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": "3",
        ///       "username": "test3",
        ///       "password": "test3",
        ///       "firstName": "test3",
        ///       "lastName": "test3",
        ///       "email": "test3",
        ///       "phoneNumber": "test3",
        ///       "role": "test3",
        ///       "status": "test3",
        ///       "lastLogin": "2024-09-25T09:00:27.824Z",
        ///       "createdAt": "2024-09-25T09:00:27.824Z",
        ///       "profileImageUrl": "test3",
        ///       "bio": "test3",
        ///       "lastPasswordChange": "2024-09-25T09:00:27.824Z",
        ///       "accountStatus": "Active",
        ///       "preferredLanguage": "test3",
        ///       "timeZone": "test3"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>User that was created</returns>
        /// <response code="200">User that was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                await _userService.CreateUserAsync(createUserRequest);

                return Ok(createUserRequest);
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

        #region Gell All Users
        /// <summary>
        /// Get all users in the system
        /// </summary>
        /// <returns>A list of all users</returns>
        /// <response code="200">Return all users in the system</response>
        /// <response code="400">If no users are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _userService.GetUserListAsync();

                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NotFound();
        }
        #endregion

        #region Get User By Id
        /// <summary>
        /// Get an user in the system
        /// </summary>
        /// <param name="id">Id of the user you want to get</param>
        /// <returns>An user</returns>
        /// <response code="200">Return an user in the system</response>
        /// <response code="400">If the user is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _userService.GetUserByIdAsync(id);

                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NotFound(new
            {
                ErrorMessage = "User does not exist"
            });
        }
        #endregion

        #region Update User
        /// <summary>
        /// Update an user in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": "3",
        ///       "username": "hello",
        ///       "passwordHash": "gggg",
        ///       "firstName": "test3",
        ///       "lastName": "test3",
        ///       "email": "test3",
        ///       "phoneNumber": "test3",
        ///       "role": "test3",
        ///       "status": "test3",
        ///       "profileImageUrl": "test3",
        ///       "bio": "test3"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>No content</returns>
        /// <response code="204">No content</response>
        /// <response code="400">User does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest updateUserRequest)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(updateUserRequest.Id);

                if (user == null) return BadRequest();

                await _userService.UpdateUserAsync(updateUserRequest);

                return Ok(updateUserRequest);
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

        #region Disable User
        /// <summary>
        /// Disable user in the system
        /// </summary>
        /// <param name="id">Id of the user you want to change</param>
        /// <response code="200">Ok</response>
        /// <response code="201">Created At</response>
        /// <response code="204">No Content</response>
        /// <response code="400">If the user is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(long id)
        {
            try
            {
                await _userService.DisableUserAsync(id);

                return Ok("Update Successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
