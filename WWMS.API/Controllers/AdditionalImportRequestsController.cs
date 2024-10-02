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
        ///       "id": 5,
        ///       "requesterName": "John Doe",
        ///       "supplier": "Supplier A",
        ///       "additionalQuantity": 100,
        ///       "totalValue": 5000,
        ///       "warehouseLocation": "Warehouse 1",
        ///       "transportDetails": "Truck XYZ, License Plate ABC123",
        ///       "comments": "Urgent request, needs to be delivered by end of the week.",
        ///       "exportRequestId": 1,
        ///       "inventoryCheckRequestId": 1,
        ///       "userId": 1,
        ///       "importRequestId": 1
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
        ///       "requestCode": "REQ-2024-001",
        ///       "requesterName": "Nguyen Van A",  
        ///       "supplier": "ABC Supplies Co.", 
        ///       "importDate": "2024-10-02T04:52:27.000Z",  
        ///       "status": "In Process", 
        ///       "additionalQuantity": 50,  
        ///       "totalValue": 15000,  
        ///       "warehouseLocation": "Warehouse A",  
        ///       "transportDetails": "Truck XYZ, License Plate 1234", 
        ///       "comments": "Needs urgent approval",  
        ///       "exportRequestId": 1, 
        ///       "inventoryCheckRequestId": 1,  
        ///       "userId": 1, 
        ///       "importRequestId": 1  
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

        #region Complete An Additional Import Request status (save data if status is complete)
        /// <summary>
        /// Complete An  Additional Import Request in the system
        /// </summary>
        /// <param name="id">Id of the  Additional Import Request you want to change</param>
        /// <response code="200">Ok</response>
        /// <response code="201">Created At</response>
        /// <response code="204">No Content</response>
        /// <response code="400">If the Additional Import Request is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut("complete-status/{id}")]
        public async Task<IActionResult> CompleteStatusAsync(long id)
        {
            try
            {
                await _additionalImport.UpdateStatusAdditionalImportRequestAsync(id);

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
