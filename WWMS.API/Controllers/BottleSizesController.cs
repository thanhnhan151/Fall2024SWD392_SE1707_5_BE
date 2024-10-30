using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.BottleSizes;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/bottle-sizes")]
    [ApiController]
    public class BottleSizesController : ControllerBase
    {
        private readonly ILogger<BottleSizesController> _logger;
        private readonly IBottleSizeService _bottleService;

        public BottleSizesController(
            ILogger<BottleSizesController> logger,
            IBottleSizeService bottleService)
        {
            _logger = logger;
            _bottleService = bottleService;
        }

        #region Create Bottle Size
        /// <summary>
        /// Add bottle size in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "bottleSizeType": "375 ml"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Bottle size that was created</returns>
        /// <response code="200">Bottle size that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateBottleSizeRequest request)
        {
            try
            {
                await _bottleService.CreateAsync(request);

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

        #region Gell All Bottle Sizes
        /// <summary>
        /// Get all bottle sizes in the system
        /// </summary>
        /// <returns>A list of all bottle sizes</returns>
        /// <response code="200">Return all bottle sizes in the system</response>
        /// <response code="400">If no bottle sizes are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _bottleService.GetAllAsync();

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
