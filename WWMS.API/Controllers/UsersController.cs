using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Users;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/users")]
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

        #region Create An User
        /// <summary>
        /// Add an user in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "username": "staff",
        ///       "firstName": "Tran Van",
        ///       "lastName": "A",
        ///       "email": "test@gmail.com",
        ///       "phoneNumber": "0123456789",
        ///       "roleId": 3
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
        //[PermissionAuthorize("ADMIN")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                await _userService.CreateUserAsync(createUserRequest);

                return Ok("Created Successfully");
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
        [PermissionAuthorize("ADMIN", "MANAGER")]
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

        #region Gell All Staffs
        /// <summary>
        /// Get all staff
        /// </summary>
        [PermissionAuthorize("ADMIN", "MANAGER")]
        [HttpGet]
        [Route("staff")]
        public async Task<IActionResult> GetAllStaffAsync()
        {
            try
            {
                var result = await _userService.GetStaffAsync();

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

        #region Get An User By Id
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
        [PermissionAuthorize("ADMIN", "MANAGER", "STAFF")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
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
                ErrorMessage = $"User with id: {id} does not exist"
            });
        }
        #endregion

        #region Update An User
        /// <summary>
        /// Update an user in the system
        /// </summary>
        /// <param name="id">Id of the user you want to update</param>
        /// <param name="updateUserRequest">User update request</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "firstName": "test3",
        ///       "lastName": "test3",
        ///       "email": "test3",
        ///       "phoneNumber": "test3",
        ///       "profileImageUrl": "test3"
        ///     }
        ///         
        /// </remarks> 
        /// <response code="200">User that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">User does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("ADMIN", "MANAGER", "STAFF")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            try
            {
                await _userService.UpdateUserAsync(id, updateUserRequest);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }
        #endregion

        #region Disable An User
        /// <summary>
        /// Disable an user in the system
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
        [PermissionAuthorize("ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(long id)
        {
            try
            {
                await _userService.DisableUserAsync(id);

                return Ok("Disabled Successfully!");
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }
        #endregion

        #region Update user password
        /// <summary>
        /// Normal user update password in profile
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "newPass": "staff",
        ///       "oldPass": "Tran Van",
        ///       "userId": "A",
        ///     }
        ///     
        /// </remarks>        
        [HttpPost]
        [Route("update-password")]
        public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordRequest updatePasswordRequest)
        {
            try
            {
                await _userService.UpdatePasswordAsync(updatePasswordRequest);

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

        #region Send code to reset password
        /// <summary>
        /// Send the code for user to reset password
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "newPass": "staff",
        ///       "oldPass": "Tran Van",
        ///       "userId": "A",
        ///     }
        ///     
        /// </remarks>
        [HttpPost]
        [Route("mail-forget-pass")]
        public async Task<IActionResult> SendCodeResetPassAsync([FromBody] SendCodeResetPassRequest sendCodeResetPassRequest)
        {
            try
            {
                await _userService.SendCodeResetPassAsync(sendCodeResetPassRequest);

                return Ok("Sent Successfully");
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

        #region Handle upload profile image
        /// <summary>
        /// The user change/ add new profile image
        /// </summary>
        /// 
        [HttpPost]
        [Route("upload-profile-image")]
        [PermissionAuthorize("ADMIN", "MANAGER", "STAFF")]
        public async Task<IActionResult> UploadProfileImageAsync(IFormFile file)
        {
            try
            {
                var imgUrl = await _userService.UploadProfileImageAsync(file);

                return Ok(imgUrl);
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
    }
}
