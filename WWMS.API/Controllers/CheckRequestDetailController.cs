using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequests;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/check-request-details")]
    [ApiController]
    public class CheckRequestDetailController : ControllerBase
    {
        #region  init
        private readonly ILogger<CheckRequestDetailController> _logger;
        private readonly ICheckRequestDetailService _checkRequestDetailService;

        public CheckRequestDetailController(
            ILogger<CheckRequestDetailController> logger,
            ICheckRequestDetailService checkRequestDetailService)
        {
            _logger = logger;
            _checkRequestDetailService = checkRequestDetailService;

        }
        #endregion

        #region Get All Check Request Details
        /// <summary>
        /// Manager get all check request details
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _checkRequestDetailService.GetAllAsync();

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

        #region Get All Check Request Details as tasks of staff
        /// <summary>
        ///Staff get all their check request details as their tasks
        /// </summary>
        [HttpGet("{reporterName}")]
        public async Task<IActionResult> GetAllByReporterNameAsync(string reporterName)
        {
            try
            {
                var result = await _checkRequestDetailService.GetAllByReporterNameAsync(reporterName);

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

        #region Create an additional check request detail
        /// <summary>
        /// Manager create an additional check request detail with existed check request
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAdditionalCheckRequestDetailRequest request)
        {
            try
            {
                await _checkRequestDetailService.CreateCheckRequestDetailAsync(request);
                return Ok("Created check request detail ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Update a check request detail
        /// <summary>
        /// Manager update the information of check request detail
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCheckRequestDetailRequest request)
        {
            try
            {
                await _checkRequestDetailService.UpdateCheckRequestDetailAsync(request);
                return Ok("Updated check request detail ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Disable the check request detail
        /// <summary>
        /// Manager disable check request detail
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(int id)
        {
            try
            {
                await _checkRequestDetailService.DisableCheckRequestDetailAsync(id);
                return Ok("Disabled check request detail ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

    }
}