using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Wines;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/wines")]
    [ApiController]
    public class WinesController : ControllerBase
    {
        private readonly ILogger<WinesController> _logger;
        private readonly IWineService _wineService;

        public WinesController(
            ILogger<WinesController> logger,
            IWineService wineService)
        {
            _logger = logger;
            _wineService = wineService;
        }

        #region Create A Bottle of Wine
        /// <summary>
        /// Add a bottle of wine in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
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
        /// <returns>Bottle of wine that was created</returns>
        /// <response code="200">User that was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUpdateWineRequest createWineRequest)
        {
            try
            {
                await _wineService.CreateWineAsync(createWineRequest);

                return Ok(createWineRequest);
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

        #region Gell All Bottles of Wine
        /// <summary>
        /// Get all bottles of wine in the system
        /// </summary>
        /// <returns>A list of all bottles of wine</returns>
        /// <response code="200">Return all bottles of wine in the system</response>
        /// <response code="400">If no bottles of wines are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _wineService.GetWineListAsync();

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

        #region Get A Bottle of Wine By Id
        /// <summary>
        /// Get a bottle of wine in the system
        /// </summary>
        /// <param name="id">Id of the bottle of wine you want to get</param>
        /// <returns>A bottle of wine</returns>
        /// <response code="200">Return a bottle of wine in the system</response>
        /// <response code="400">If the bottle of wine is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _wineService.GetWineByIdAsync(id);

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
                ErrorMessage = $"Bottle of wine with id: {id} does not exist"
            });
        }
        #endregion

        #region Update A Bottle of Wine
        /// <summary>
        /// Update a bottle of wine in the system
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
        /// <response code="200">Bottle of wine that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">Bottle of wine does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CreateUpdateWineRequest updateWineRequest)
        {
            try
            {
                var user = await _wineService.GetWineByIdAsync(updateWineRequest.Id);

                if (user == null) return NotFound(new
                {
                    ErrorMessage = $"Bottle of wine with id: {updateWineRequest.Id} does not exist"
                });

                await _wineService.UpdateWineAsync(updateWineRequest);

                return Ok(updateWineRequest);
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

        #region Disable A Bottle of Wine
        /// <summary>
        /// Disable a bottle of wine in the system
        /// </summary>
        /// <param name="id">Id of the bottle of wine you want to change</param>
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
                await _wineService.DisableWineAsync(id);

                return Ok("Update Successfully!");
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
    }
}
