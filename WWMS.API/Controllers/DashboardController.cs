using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/dashboard")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDashBoardService _dashBoardService;


        public DashboardController(
            ILogger<DashboardController> logger,
            IDashBoardService dashBoardService)
        {
            _logger = logger;
            _dashBoardService = dashBoardService;
        }

        #region Gell All Import/Export Request
        /// <summary>
        /// Get all Import/Export Request in the system
        /// </summary>
        /// <returns>A list of all Import/Export Request</returns>
        /// <response code="200">Return all Import/Export Request in the system</response>
        /// <response code="400">If no Import/Export Request are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int month, int year)
        {
            try
            {
                var result = await _dashBoardService.GetQuantityPerMonthListAsync(month, year);

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
