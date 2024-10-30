using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Rooms;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ILogger<RoomsController> _logger;
        private readonly IRoomService _roomService;

        public RoomsController(
            ILogger<RoomsController> logger,
            IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }

        #region Create A Room
        /// <summary>
        /// Add a room in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "roomName": "Hybrid Overdrive",
        ///       "locationAddress": "In the middle of nowhere",
        ///       "capacity": 100,
        ///       "managerName": "Tran Van Bao"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Room that was created</returns>
        /// <response code="200">Room that was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateRoomRequest createRoomRequest)
        {
            try
            {
                await _roomService.CreateRoomAsync(createRoomRequest);

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

        #region Gell All Rooms
        /// <summary>
        /// Get all rooms in the system
        /// </summary>
        /// <returns>A list of all rooms</returns>
        /// <response code="200">Return all rooms in the system</response>
        /// <response code="400">If no rooms are in the system</response>
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
                var result = await _roomService.GetRoomListAsync();

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

        #region Gell All Available Rooms
        /// <summary>
        /// Get all available rooms in the system
        /// </summary>
        /// <returns>A list of all available rooms</returns>
        /// <response code="200">Return all available rooms in the system</response>
        /// <response code="400">If no available rooms are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet("available")]
        public async Task<IActionResult> GetAllAvailableAsync()
        {
            try
            {
                var result = await _roomService.GetAvailableRoomListAsync();

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

        #region Get A Room By Id
        /// <summary>
        /// Get a room in the system
        /// </summary>
        /// <param name="id">Id of the room you want to get</param>
        /// <returns>An Room</returns>
        /// <response code="200">Return ar room in the system</response>
        /// <response code="400">If the Room is null</response>
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
                var result = await _roomService.GetRoomByIdAsync(id);

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
                ErrorMessage = $"Room with id: {id} does not exist"
            });
        }
        #endregion

        #region Update A Room
        /// <summary>
        /// Update a room in the system
        /// </summary>
        /// <param name="id">Id of the room you want to update</param>
        /// <param name="updateRoomRequest">Room update request</param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "roomName": "Vintage Only",
        ///       "locationAddress": "On the very top",
        ///       "capacity": 100,
        ///       "currentOccupancy": 1,
        ///       "managerName": "Tran Van Teo"
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
        //[PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateRoomRequest updateRoomRequest)
        {
            try
            {
                await _roomService.UpdateRoomAsync(id, updateRoomRequest);

                return Ok("Updated Successfully");
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

        #region Disable A Room
        /// <summary>
        /// Disable a room in the system
        /// </summary>
        /// <param name="id">Id of the room you want to change</param>
        /// <response code="200">Ok</response>
        /// <response code="201">Created At</response>
        /// <response code="204">No Content</response>
        /// <response code="400">If the room is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("MANAGER")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableAsync(long id)
        {
            try
            {
                await _roomService.DisableRoomAsync(id);

                return Ok("Disabled Successfully!");
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
