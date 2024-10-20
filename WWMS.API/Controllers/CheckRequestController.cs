using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequests;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/checkrequests")]
    [ApiController]
    public class CheckRequestController : ControllerBase
    {

        private readonly ILogger<CheckRequestController> _logger;
        #region init
        private readonly ICheckRequestService _checkRequestService;

        public CheckRequestController(
            ILogger<CheckRequestController> logger,
            ICheckRequestService checkRequestService)
        {
            _logger = logger;


        }
        #endregion

        #region Get All Check Requests
        /// <summary>
        /// Manager, Admin get all check requests
        /// </summary>
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
        /// Manager, Admin create check request
        /// </summary>
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(int id, [FromBody] DisableCheckRequestRequest request)
        {
            try
            {
                await _checkRequestService.DisableAsync(id,request);
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