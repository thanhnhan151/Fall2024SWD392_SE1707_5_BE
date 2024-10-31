using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Roles;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService _roleService;

        public RolesController(
            ILogger<RolesController> logger,
            IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }

        #region Create Role
        /// <summary>
        /// Add a role in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "roleName": "Admin"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Role that was created</returns>
        /// <response code="200">Role that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("ADMIN")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateRoleRequest request)
        {
            try
            {
                await _roleService.CreateAsync(request);

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

        #region Gell All Roles
        /// <summary>
        /// Get all roles in the system
        /// </summary>
        /// <returns>A list of all roles</returns>
        /// <response code="200">Return all roles in the system</response>
        /// <response code="400">If no roles are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _roleService.GetAllAsync();

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
    }
}
