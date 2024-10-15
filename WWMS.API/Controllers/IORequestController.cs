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

        #region Create A Import/Export Request
        /// <summary>
        /// Add a room in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///{
        ///  "requestCode": "REQ-001",
        ///  "totalQuantity": 10,
        ///  "comments": "Request for inventory adjustment.",
        ///  "ioType": "Adjustment",
        ///  "priorityLevel": "High",
        ///  "requesterId": 2,
        ///  "requesterName": "John Doe",
        ///  "ioRequestDetails": [
        ///    {
        ///      "quantity": 5,
        ///      "startDate": "2024-10-13T08:34:48.529Z",
        ///      "endDate": "2024-10-20T08:34:48.529Z",
        ///      "createdTime": "2024-10-13T08:34:48.529Z",
        ///      "updatedTime": "2024-10-13T08:34:48.529Z",
        ///      "deletedTime": null,
        ///      "comments": "Adjusting inventory for special event.",
        ///      "wineId": 5,
        ///      "supplier": "Wine Supplier Co.",
        ///      "wineName": "Chardonnay",
        ///      "mfd": "2023-01-15T08:34:48.529Z",
        ///      "roomId": 2,
        ///      "roomName": "Main Storage Room",
        ///      "ioRequestCode": "IO-REQ-001",
        ///      "checkerId": 2,
        ///      "checkerName": "Jane Smith",
        ///      "wineRoomId": 5,
        ///      "reportCode": "RPT-001",
        ///      "reportDescription": "Inventory adjustment report.",
        ///      "reporterAssigned": "John Doe",
        ///      "discrepanciesFound": 0,
        ///      "actualQuantity": 5,
        ///      "reportFile": "path/to/report/file.pdf"
        ///    }
        ///  ]
        ///}
        ///         
        /// </remarks> 
        /// <returns>Room that was created</returns>
        /// <response code="200">Room that was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
    
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateIORequest createIORequest)
        {
            try
            {
                await _iORequestService.CreateIORequestsAsync(createIORequest);

                return Ok(createIORequest);
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
        /// Update a room in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": 1,
        ///       "roomName": "staff",
        ///       "locationAddress": "staff",
        ///       "capacity": "Tran Van",
        ///       "currentOccupancy": "A",
        ///       "managerName": "test@gmail.com",
        ///       "wineRooms": [
        ///         {
        ///           "currQuantity": 10,
        ///           "totalQuantity": 20,
        ///           "roomId": 2,
        ///           "wineId": 1
        ///         },
        ///         {
        ///           "currQuantity": 10,
        ///           "totalQuantity": 20,
        ///           "roomId": 2,
        ///           "wineId": 2         
        ///         }
        ///       ]
        ///     }
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateIORequest updateIO)
        {
            try
            {
                var Room = await _iORequestService.GetIORequestsByIdAsync(updateIO.Id);

                if (Room == null) return NotFound(new
                {
                    ErrorMessage = $" Import/Export with id: {updateIO.Id} does not exist"
                }); ;

                await _iORequestService.UpdateIORequestsAsync(updateIO);

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




