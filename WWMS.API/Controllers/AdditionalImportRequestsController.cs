using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.AdditionalImportRequests;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/additional-import-requests")]
    [ApiController]
    public class AdditionalImportRequestsController : ControllerBase
    {
        private readonly ILogger<AdditionalImportRequestsController> _logger;
        private readonly IAdditionalImportRequestService _additionalImport;
        public AdditionalImportRequestsController(ILogger<AdditionalImportRequestsController> logger, IAdditionalImportRequestService importService)
        {
            _logger = logger;
            _additionalImport = importService;
        }

        #region Gell All Addition Import Requests
        /// <summary>
        /// Get all Addition Import Requests  in the system
        /// </summary>
        /// <returns>A list of all Addition Import Requests </returns>
        /// <response code="200">Return all Addition Import Requests  in the system</response>
        /// <response code="400">If no Addition Import Requests  are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _additionalImport.GetAdditionalImportRequestAsync();

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

        #region Gell All Addition Import Requests
        /// <summary>
        /// Get an Addition Import in the system
        /// </summary>
        /// <param name="id">Id of the Addition Import you want to get</param>
        /// <returns>An user</returns>
        /// <response code="200">Return an Addition Import in the system</response>
        /// <response code="400">If the Addition Import is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                var result = await _additionalImport.GetAdditionalImportRequestIdAsync(id);

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

        #region Create An Addition Import Requests
        /// <summary>
        /// Add an Addition Import Requests in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": 0,
        ///       "requesterName": "string",
        ///       "supplier": "string",
        ///       "additionalQuantity": 0,
        ///       "totalValue": 0,
        ///       "warehouseLocation": "string",
        ///       "transportDetails": "string",
        ///       "comments": "string",
        ///       "exportRequestId": 0,
        ///       "inventoryCheckRequestId": 0,
        ///       "userId": 0,
        ///       "importRequestId": 0
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Addition Import Requests  that was created</returns>
        /// <response code="200">Addition Import Requests that was created</response>
        /// <response code="400">Failed validation , Wine was null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateAdditionalImportRequest createImport)
        {
            try
            {
                await _additionalImport.CreateAdditionalImportRequestAnync(createImport);
                var Im = await _additionalImport.GetAdditionalImportRequestIdAsync(createImport.Id);
                return Ok(Im);
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

        #region Update An Addition Import Request
        /// <summary>
        /// Add an user in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": 1, 
        ///       "requestCode": "REQ-001",
        ///       "requesterName": "John Doe",
        ///       "supplier": "Supplier A",
        ///       "importDate": "2024-09-25T00:00:00",
        ///       "status": "Pending",
        ///       "totalQuantity": 100,
        ///       "totalValue": 1500,
        ///       "warehouseLocation": "Warehouse 1",
        ///       "transportDetails": "Transport by truck",
        ///       "comments": "No comments",
        ///       "customsClearance": "Cleared",
        ///       "deliveryStatus": "In transit",
        ///       "expectedArrival": "2024-10-01T00:00:00",
        ///       "insuranceProvider": "Insurance Co",
        ///       "shippingMethod": "Air freight",
        ///       "taxDetails": "Tax ID: 123456",
        ///       "wineId": 1,
        ///       "userId": 1,
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Addition Import  that was created</returns>
        /// <response code="200">Import request that was created</response>
        /// <response code="400">Failed validation, Wine was null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAdditionalImportRequest updateRequest)
        {
            try
            {
                var user = await _additionalImport.GetAdditionalImportRequestIdAsync(updateRequest.Id);

                if (user == null) return NotFound(new
                {
                    ErrorMessage = $"id: {updateRequest.Id} does not exist"
                });

                await _additionalImport.UpdateAdditionalImportRequestAsync(updateRequest);

                return Ok(updateRequest);
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

        #region Cancel An Addition Import Request status
        /// <summary>
        /// Disable Addition Import Request in the system
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
        [HttpPut("cancel-status/{id}")]
        public async Task<IActionResult> CanncelStatusAsync(long id)
        {
            try
            {
                await _additionalImport.DisableAdditionalImportRequestAsync(id);

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
