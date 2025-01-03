using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequestReports;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/check-request-reports")]
    [ApiController]
    public class ReportCheckRequestController : ControllerBase
    {
        #region init
        private readonly IReportCheckRequestService _reportCheckRequestService;
        private readonly ILogger<ReportCheckRequestController> _logger;

        public ReportCheckRequestController(
            ILogger<ReportCheckRequestController> logger,
            IReportCheckRequestService reportCheckRequestService)
        {
            _logger = logger;
            _reportCheckRequestService = reportCheckRequestService;
        }
        #endregion

        #region create report for a check request detail
        /// <summary>
        /// Staff/Manager create a report for check request detail
        /// </summary>
        [HttpPost]
        [PermissionAuthorize("MANAGER", "STAFF")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCheckRequestReportRequest request)
        {
            try
            {
                await _reportCheckRequestService.CreateCheckRequestReportAsync(request);
                return Ok("Created check request report ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #endregion

    }
}