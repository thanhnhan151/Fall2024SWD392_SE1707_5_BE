using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Services;

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
        //[PermissionAuthorize("Staff")]
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
        ///     {
        ///       "requestCode": "REQ-001",
        ///       "startDate": "2024-10-19T17:05:05.759Z",
        ///       "dueDate": "2024-10-19T17:05:05.759Z",
        ///       "comments": "Request for wine intake",
        ///       "ioType": "In",
        ///       "supplierName": "Supplier ABC",
        ///       "customerName": "Customer XYZ",
        ///       "roomId": 0,
        ///       "checkerId": 0,
        ///       "ioRequestDetails": [
        ///         {
        ///           "quantity": 10,
        ///           "wineId": 0
        ///         },
        ///         {
        ///           "quantity": 5,
        ///           "wineId": 0
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

        #region Update A Import/Export Request
        /// <summary>
        /// Update an Import/Export request in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": 0,
        ///       "requestCode": "REQ-002",
        ///       "startDate": "2024-10-19T17:13:26.774Z",
        ///       "dueDate": "2024-10-20T17:13:26.774Z",
        ///       "comments": "Request for wine intake",
        ///       "ioType": "In",
        ///       "supplierName": "Supplier XYZ",
        ///       "customerName": "Customer ABC",
        ///       "roomId": 0,
        ///       "checkerId": 0,
        ///       "status": "Pending",
        ///       "upIORequestDetails": [
        ///         {
        ///           "id": 0,
        ///           "quantity": 5,
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
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateIORequest updateIO)
        {
            try
            {
                var Room = await _iORequestService.GetIORequestsByIdAsync(updateIO.Id);

                if (Room == null) return NotFound(new
                {
                    ErrorMessage = $" Import/Export with id: {updateIO.Id} does not exist"
                });

                await _iORequestService.UpdateIORequestsAsync(updateIO);

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
    }

}




