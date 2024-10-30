using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Corks;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/corks")]
    [ApiController]
    public class CorksController : ControllerBase
    {
        private readonly ILogger<CorksController> _logger;
        private readonly ICorkService _corkService;

        public CorksController(
            ILogger<CorksController> logger,
            ICorkService corkService)
        {
            _logger = logger;
            _corkService = corkService;
        }

        #region Create Cork
        /// <summary>
        /// Add a cork in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "corkType": "Cork"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Cork that was created</returns>
        /// <response code="200">Cork that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCorkRequest request)
        {
            try
            {
                await _corkService.CreateAsync(request);

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

        #region Gell All Corks
        /// <summary>
        /// Get all corks in the system
        /// </summary>
        /// <returns>A list of all corks</returns>
        /// <response code="200">Return all corks in the system</response>
        /// <response code="400">If no corks are in the system</response>
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
                var result = await _corkService.GetAllAsync();

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
