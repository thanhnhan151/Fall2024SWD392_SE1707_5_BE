using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.IORequests.IOrequestdetails;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/iorequests")]
    [ApiController]
    public class IORequestController : ControllerBase
    {
        private readonly ILogger<IORequestController> _logger;
        private readonly IIORequestService _iORequestService;
        private readonly IVnPayService _vnPayService;

        public IORequestController(
            ILogger<IORequestController> logger,
            IIORequestService iORequestService,
            IVnPayService vnPayService)
        {
            _logger = logger;
            _iORequestService = iORequestService;
            _vnPayService = vnPayService;
        }

        #region Gell All Import/Export Request
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
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _iORequestService.GetIORequestsListAsync();

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

        #region Get A Import/Export By Id
        /// <summary>
        /// Get a Import/Export in the system
        /// </summary>
        /// <param name="id">Id of the Import/Export you want to get</param>
        /// <returns>An Room</returns>
        /// <response code="200">Return ar Import/Export in the system</response>
        /// <response code="400">If the Import/Export is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _iORequestService.GetIORequestsByIdAsync(id);

                if (result is not null)
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

        #region Create An Import/Export Request
        /// <summary>
        /// Create a new Import/Export request in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Import
        ///     
        ///     {
        ///       "requestCode": "REQ-001",
        ///       "startDate": "2024-10-25T21:51:14.383Z",
        ///       "comments": "Import",
        ///       "ioType": "In",
        ///       "roomId": 1,
        ///       "checkerId": 2,
        ///       "suplierId": 1,
        ///       "ioRequestDetails": [
        ///         {
        ///           "quantity": 10,
        ///           "wineId": 1
        ///         }
        ///       ]
        ///     }
        ///     
        ///     Export
        ///     
        ///     {
        ///       "requestCode": "REQ-001",
        ///       "startDate": "2024-10-25T21:51:14.383Z",
        ///       "comments": "Export",
        ///       "ioType": "Out",
        ///       "roomId": 1,
        ///       "checkerId": 2,
        ///       "customerId": 1,
        ///       "ioRequestDetails": [
        ///         {
        ///           "quantity": 10,
        ///           "wineId": 1
        ///         }
        ///       ]
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Confirmation message of the created Import/Export request</returns>
        /// <response code="200">Request created successfully</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateIORequest createIORequest)
        {
            try
            {
                await _iORequestService.CreateIORequestsAsync(createIORequest);

                return Ok("Created Successfully");
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

        #region Update A Import/Export Request many
        /// <summary>
        /// Update an Import/Export request in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "requestCode": "string",
        ///       "startDate": "2024-10-26T02:52:20.461Z",
        ///       "dueDate": "2024-10-26T02:52:20.461Z",
        ///       "comments": "string",
        ///       "ioType": "string",
        ///       "roomId": 0,
        ///       "checkerId": 0,
        ///       "suplierId": 0,
        ///       "customerId": 0,
        ///       "status": "string",
        ///       "upIORequestDetails": [
        ///         {
        ///           "id": 0,
        ///           "quantity": 0,
        ///           "wineId": 0
        ///         }
        ///       ]
        ///     }
        ///         
        /// </remarks> 
        /// <response code="200">Request that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">Request does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateIORequest updateIO, long id)
        {
            try
            {
                await _iORequestService.UpdateManyIORequestsAsync(updateIO, id);

                return Ok("Update Successfully");
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

        #region Import Checkout
        /// <summary>
        /// Check out an import request in the system
        /// </summary>
        /// <param name="id">Id of the import request you want to pay</param>
        /// <returns>An url to  VnPay</returns>
        /// <response code="200">Return an url to VnPay</response>
        /// <response code="400">If the import request is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("STAFF")]
        [HttpPost("{id}/payment")]
        public async Task<IActionResult> CreateAsync(int id)
        {
            var url = await _vnPayService.CreateUrl(id);

            return Ok(new
            {
                PaymentUrl = url
            });
        }
        #endregion

        #region Disable An Import/Export 
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
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(long id)
        {
            try
            {
                await _iORequestService.DisableIORequestsAsync(id);

                return Ok("Disable Successfully!");
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

        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet("style")]
        public async Task<IActionResult> GetAllByIOStyleAsync(string io)
        {
            try
            {
                var result = await _iORequestService.GetAllEntitiesByIOStyle(io);

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

        #region Create  Import/Export Request details
        /// <summary>
        /// Update an Import/Export request in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "ioRequestDetails": [
        ///         {
        ///           "quantity": 0,
        ///           "wineId": 0
        ///         }
        ///       ]
        ///     }
        ///         
        /// </remarks> 
        /// <response code="200">Request that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">Request does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPut("Create-details/{id}")]
        public async Task<IActionResult> UpdateDetailsAsync([FromBody] CreateDetailsById updateIO, long id)
        {
            try
            {
                await _iORequestService.CreateManyIORequestDetailsByIdAsync(updateIO, id);

                return Ok("Update Successfully");
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

        #region Update Import/Export Request details
        /// <summary>
        /// Update an Import/Export request in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "ioRequestDetails": [
        ///         {
        ///           "id" : 0,
        ///           "quantity": 0,
        ///           "wineId": 0
        ///         }
        ///       ]
        ///     }
        ///         
        /// </remarks> 
        /// <response code="200">Request that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">Request does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPut("update-details/{id}")]
        public async Task<IActionResult> UpdateDetailsAsync([FromBody] UpdateDetailsById updateIO, long id)
        {
            try
            {
                await _iORequestService.UpdateManyIORequestDetailsByIdAsync(updateIO, id);

                return Ok("Update Successfully");
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

        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPut("delete-details/{id}")]
        public async Task<IActionResult> DeleteDetailsAsync(long id, long detailIds)
        {
            try
            {
                await _iORequestService.RemoveIORequestDetailByIdAsync(id, detailIds);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }

        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPut("done/{id}")]
        public async Task<IActionResult> DonesAsync(long id)
        {
            try
            {
                await _iORequestService.DoneIORequestsAsync(id);

                return Ok("Update Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}




