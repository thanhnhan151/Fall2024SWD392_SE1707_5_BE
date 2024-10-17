using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.ReportIORequest;
using WWMS.BAL.Services;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/reports")]
    [ApiController]
    public class ReportIORequestController : ControllerBase
    {
        private readonly ILogger<ReportIORequestController> _logger;
        private readonly IReportIORequestService _reportIORequest;
        private readonly IUploadFileService _uploadFileService;

        public ReportIORequestController(
            ILogger<ReportIORequestController> logger,
            IReportIORequestService reportIORequest,
            IUploadFileService uploadFileService)
        {
            _logger = logger;
            _reportIORequest = reportIORequest;
            _uploadFileService = uploadFileService;
        }

        #region Gell All Report Import/Export Request
        /// <summary>
        /// Get Report all Import/Export Request in the system
        /// </summary>
        /// <returns>A list of all Report Import/Export Request details </returns>
        /// <response code="200">Return all Import/Export Request in the system</response>
        /// <response code="400">If no Import/Export Request are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _reportIORequest.GetReportIORequestListAsync();

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

        #region Get A Report Import/Export By Id
        /// <summary>
        /// Get a Report Import/Export in the system
        /// </summary>
        /// <param name="id">Id of the Report Import/Export you want to get</param>
        /// <returns>An Room</returns>
        /// <response code="200">Return ar Import/Export in the system</response>
        /// <response code="400">If the Import/Export is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _reportIORequest.GetReportIORequestByIdAsync(id);

                if (result is not null && result.ReportCode.IsNullOrEmpty())
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return NotFound(new
            {
                ErrorMessage = $"Import/Export with id: {id} does not exist"
            });
        }
        #endregion


        #region Update A report for Import/Export Request
        /// <summary>
        /// Update a room in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        /// </remarks> 
        /// <response code="200">Room that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">Room does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] UpdateReportIORequest updateIO, IFormFile doc)
        {
            try
            {
                var rep = await _reportIORequest.GetReportIORequestByIdAsync(updateIO.Id);

                if (rep == null)
                {
                    return NotFound(new
                    {
                        ErrorMessage = $"rep Import/Export with id: {updateIO.Id} does not exist"
                    });
                }

                string file = null; 

           
                if (doc != null)
                {
                    file = await _uploadFileService.UploadImage(doc);
                }
                await _reportIORequest.UpdateReportIORequestAsync(updateIO, file);
                

                return Ok(updateIO);
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

        #region Disable An Import/Export and details
        /// <summary>
        /// Disable an Disable An Import/Export  in the system
        /// </summary>
        /// <param name="id">Id of the user you want to change</param>
        /// <response code="200">Ok</response>
        /// <response code="201">Created At</response>
        /// <response code="204">No Content</response>
        /// <response code="400">If the user is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(long id)
        {
            try
            {
                await _reportIORequest.DisableReportIORequestsAsync(id);

                return Ok("Update Successfully!");
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }
        #endregion

    }
}
