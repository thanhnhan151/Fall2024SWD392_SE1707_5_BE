using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.ImportRequests;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/import-requests")]
    [ApiController]
    public class ImportRequestsController : ControllerBase
    {
        private readonly ILogger<ImportRequestsController> _logger;
        private readonly IImportRequestService _importService;

        public ImportRequestsController(ILogger<ImportRequestsController> logger, IImportRequestService importService)
        {
            _logger = logger;
            _importService = importService;
        }
        #region Gell All Import Requests
        /// <summary>
        /// Get all Import Request  in the system
        /// </summary>
        /// <returns>A list of all Import Request </returns>
        /// <response code="200">Return all Import Request  in the system</response>
        /// <response code="400">If no Import Request  are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _importService.GetImportRequestAsync();

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

        #region Get An Import Request By Id
        /// <summary>
        /// Get an ImportRequest in the system
        /// </summary>
        /// <param name="id">Id of the ImportRequest you want to get</param>
        /// <returns>An user</returns>
        /// <response code="200">Return an ImportRequest in the system</response>
        /// <response code="400">If the ImportRequest is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                var result = await _importService.GetImportRequestByIdAsync(id);

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

        #region Create An Import Request
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
        /// <returns>ImPort  that was created</returns>
        /// <response code="200">ImPort that was created</response>
        /// <response code="400">Failed validation , Wine was null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateImportRequest createImport)
        {
            try
            {
                await _importService.CreateImportRequestAnync(createImport);
                var Im = await _importService.GetImportRequestByIdAsync(createImport.Id);
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

        #region Update An Import Request
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
        /// <returns>Import request  that was created</returns>
        /// <response code="200">Import request that was created</response>
        /// <response code="400">Failed validation, Wine was null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateImportRequest updateRequest)
        {
            try
            {
                var user = await _importService.GetImportRequestByIdAsync(updateRequest.Id);

                if (user == null) return NotFound(new
                {
                    ErrorMessage = $"id: {updateRequest.Id} does not exist"
                });

                await _importService.UpdateImportRequestAsync(updateRequest);

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

        #region Disable An Import Request
        /// <summary>
        /// Disable user in the system
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
                await _importService.DisableImportRequestAsync(id);

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
