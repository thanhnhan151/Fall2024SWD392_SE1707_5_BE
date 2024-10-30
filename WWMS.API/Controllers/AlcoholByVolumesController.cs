using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.AlcoholByVolumes;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/alcohol-by-volumes")]
    [ApiController]
    public class AlcoholByVolumesController : ControllerBase
    {
        private readonly ILogger<AlcoholByVolumesController> _logger;
        private readonly IAlcoholByVolumeService _alcoholService;

        public AlcoholByVolumesController(
            ILogger<AlcoholByVolumesController> logger,
            IAlcoholByVolumeService alcoholService)
        {
            _logger = logger;
            _alcoholService = alcoholService;
        }

        #region Create Alcohol Volume
        /// <summary>
        /// Add alcohol volume in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "alcoholByVolumeType": "5%"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Alcohol volume that was created</returns>
        /// <response code="200">Alcohol volume that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateVolumeRequest request)
        {
            try
            {
                await _alcoholService.CreateAsync(request);

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

        #region Gell All Alcohol Volumes
        /// <summary>
        /// Get all alcohol volumes in the system
        /// </summary>
        /// <returns>A list of all alcohol volumes</returns>
        /// <response code="200">Return all alcohol volumes in the system</response>
        /// <response code="400">If no alcohol volumes are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _alcoholService.GetAllAsync();

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
