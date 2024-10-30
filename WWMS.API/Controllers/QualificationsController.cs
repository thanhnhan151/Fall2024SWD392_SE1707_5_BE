using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Qualifications;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/qualifications")]
    [ApiController]
    public class QualificationsController : ControllerBase
    {
        private readonly ILogger<QualificationsController> _logger;
        private readonly IQualificationService _qualifiService;

        public QualificationsController(
            ILogger<QualificationsController> logger,
            IQualificationService qualifiService)
        {
            _logger = logger;
            _qualifiService = qualifiService;
        }

        #region Create Qualification
        /// <summary>
        /// Add qualification in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "qualificationType": "Biodynamic"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Qualification that was created</returns>
        /// <response code="200">Qualification that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateQualifcationRequest request)
        {
            try
            {
                await _qualifiService.CreateAsync(request);

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

        #region Gell All Qualifications
        /// <summary>
        /// Get all qualifications in the system
        /// </summary>
        /// <returns>A list of all qualifications</returns>
        /// <response code="200">Return all qualifications in the system</response>
        /// <response code="400">If no qualifications are in the system</response>
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
                var result = await _qualifiService.GetAllAsync();

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
