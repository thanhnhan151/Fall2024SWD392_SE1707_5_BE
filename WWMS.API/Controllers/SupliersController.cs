using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Supliers;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/supliers")]
    [ApiController]
    public class SupliersController : ControllerBase
    {
        private readonly ILogger<SupliersController> _logger;
        private readonly ISuplierService _suplierService;

        public SupliersController(
            ILogger<SupliersController> logger,
            ISuplierService suplierService)
        {
            _logger = logger;
            _suplierService = suplierService;
        }

        #region Create Suplier
        /// <summary>
        /// Add a suplier in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "suplierName": "Admin"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Suplier that was created</returns>
        /// <response code="200">Suplier that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateSuplierRequest request)
        {
            try
            {
                await _suplierService.CreateAsync(request);

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

        #region Gell All Supliers
        /// <summary>
        /// Get all supliers in the system
        /// </summary>
        /// <returns>A list of all supliers</returns>
        /// <response code="200">Return all supliers in the system</response>
        /// <response code="400">If no supliers are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _suplierService.GetAllAsync();

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
