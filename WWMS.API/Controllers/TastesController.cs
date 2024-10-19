using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Tastes;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/tastes")]
    [ApiController]
    public class TastesController : ControllerBase
    {
        private readonly ILogger<TastesController> _logger;
        private readonly ITasteService _tasteService;

        public TastesController(
            ILogger<TastesController> logger,
            ITasteService tasteService)
        {
            _logger = logger;
            _tasteService = tasteService;
        }

        #region Create Taste
        /// <summary>
        /// Add taste in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "tasteType": "Dry"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Taste that was created</returns>
        /// <response code="200">Taste that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER", "ADMIN")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateTasteRequest request)
        {
            try
            {
                await _tasteService.CreateAsync(request);

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

        #region Gell All Tastes
        /// <summary>
        /// Get all tastes in the system
        /// </summary>
        /// <returns>A list of all tastes</returns>
        /// <response code="200">Return all tastes in the system</response>
        /// <response code="400">If no tastes are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Manager", "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _tasteService.GetAllAsync();

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
