using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
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
        /// Staff create a report for check request detail
        /// </summary>
        [HttpPost]
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

        #region update report for a check request detail
        /// <summary>
        /// Staff update a check request report
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCheckRequestReportRequest request)
        {
            try
            {
                await _reportCheckRequestService.UpdateCheckRequestReportAsync(request);
                return Ok("Updated check request report ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion


        #region get report by check request detail id

        /// <summary>
        /// User get the report by the check request detail id
        /// </summary>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCheckRequestDetailIdAsync(int id)
        {
            try
            {
                var result = await _reportCheckRequestService.GetReportByCheckRequestDetailIdAsync(id);

                if (result is not null)
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
            return NotFound();
        }
        #endregion






    }
}