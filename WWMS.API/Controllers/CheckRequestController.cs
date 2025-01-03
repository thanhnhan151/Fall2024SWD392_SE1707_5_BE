using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequests;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/check-requests")]
    [ApiController]
    public class CheckRequestController : ControllerBase
    {

        #region init
        private readonly ICheckRequestService _checkRequestService;
        private readonly ILogger<CheckRequestController> _logger;

        public CheckRequestController(
            ILogger<CheckRequestController> logger,
            ICheckRequestService checkRequestService)
        {
            _logger = logger;
            _checkRequestService = checkRequestService;
        }
        #endregion

        #region Get All Check Requests
        /// <summary>
        /// Manager, Admin get all check requests
        /// </summary>
        [PermissionAuthorize("MANAGER")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _checkRequestService.GetCheckRequestListAsync();

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

        #region Get Check Request Information (include list details) By CheckRequestID
        /// <summary>
        /// Manager, Admin get Check Request Information (include details) By CheckRequestID
        /// </summary>
        [PermissionAuthorize("MANAGER")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _checkRequestService.GetCheckRequestByIdAsync(id);

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

        #region Create a check request
        /// <summary>
        /// Manager create check request
        /// </summary>
        [PermissionAuthorize("MANAGER")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCheckRequestRequest request)
        {
            try
            {
                await _checkRequestService.CreateRequestAsync(request);
                return Ok("Created check request ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Update a check request
        /// <summary>
        /// Manager, Admin update check request
        /// </summary>
        [PermissionAuthorize("MANAGER")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCheckRequestRequest request)
        {
            try
            {
                await _checkRequestService.UpdateCheckRequestAsync(request);
                return Ok("Updated check request ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion

        #region Disable the check request
        /// <summary>
        /// Manager disable check request => disable relations too
        /// </summary>
        [PermissionAuthorize("MANAGER")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(int id)
        {
            try
            {
                await _checkRequestService.DisableAsync(id);
                return Ok("Disabled check request ok!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}