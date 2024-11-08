using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
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

        #region Gell All Import/Export , over stock or lack of stock  Request
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
        [PermissionAuthorize("ADMIN", "MANAGER")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int year)
        {
            try
            {
                var result = await _dashBoardService.GetQuantityPerMonthListAsync(year);

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

        #region Gell All wine and room store this wine 
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
        [PermissionAuthorize("ADMIN", "MANAGER")]
        [HttpGet("quantity")]
        public async Task<IActionResult> GetAllWineAsync()
        {
            try
            {
                var result = await _dashBoardService.GetQuantityWineListAsync();

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

        #region Gell All wine by category 
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
        [PermissionAuthorize("ADMIN", "MANAGER")]
        [HttpGet("quantityCategory")]
        public async Task<IActionResult> GetAllWinebyCategoryAsync()
        {
            try
            {
                var result = await _dashBoardService.GetQuantityWineListCategoryAsync();

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

        #region Gell All Import/Export quantity
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
        [PermissionAuthorize("ADMIN", "MANAGER")]
        [HttpGet("quantityIo")]
        public async Task<IActionResult> GetIOAllAsync(int year)
        {
            try
            {
                var result = await _dashBoardService.GetQuantityPerMonthIOListAsync(year);

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
