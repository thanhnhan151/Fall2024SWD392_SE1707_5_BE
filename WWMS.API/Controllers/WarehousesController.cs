using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Warehouses;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/warehouses")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly ILogger<WarehousesController> _logger;
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(
            ILogger<WarehousesController> logger,
            IWarehouseService warehouseService)
        {
            _logger = logger;
            _warehouseService = warehouseService;
        }

        #region Create A Warehouse
        /// <summary>
        /// Add a warehouse in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": "3",
        ///       "Warehousename": "test3",
        ///       "password": "test3",
        ///       "firstName": "test3",
        ///       "lastName": "test3",
        ///       "email": "test3",
        ///       "phoneNumber": "test3",
        ///       "role": "test3",
        ///       "status": "test3",
        ///       "lastLogin": "2024-09-25T09:00:27.824Z",
        ///       "createdAt": "2024-09-25T09:00:27.824Z",
        ///       "profileImageUrl": "test3",
        ///       "bio": "test3",
        ///       "lastPasswordChange": "2024-09-25T09:00:27.824Z",
        ///       "accountStatus": "Active",
        ///       "preferredLanguage": "test3",
        ///       "timeZone": "test3"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Warehouse that was created</returns>
        /// <response code="200">Warehouse that was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateUpdateWarehouseRequest createWarehouseRequest)
        {
            try
            {
                await _warehouseService.CreateWarehouseAsync(createWarehouseRequest);

                return Ok(createWarehouseRequest);
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

        #region Gell All Warehouses
        /// <summary>
        /// Get all warehouses in the system
        /// </summary>
        /// <returns>A list of all warehouses</returns>
        /// <response code="200">Return all warehouses in the system</response>
        /// <response code="400">If no warehouses are in the system</response>
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
                var result = await _warehouseService.GetWarehouseListAsync();

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

        #region Get A Warehouse By Id
        /// <summary>
        /// Get a warehouse in the system
        /// </summary>
        /// <param name="id">Id of the warehouse you want to get</param>
        /// <returns>A warehouse</returns>
        /// <response code="200">Return a warehouse in the system</response>
        /// <response code="400">If the warehouse is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _warehouseService.GetWarehouseByIdAsync(id);

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
                ErrorMessage = $"Warehouse with id: {id} does not exist"
            });
        }
        #endregion

        #region Update A Warehouse
        /// <summary>
        /// Update a Warehouse in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": "3",
        ///       "Warehousename": "hello",
        ///       "passwordHash": "gggg",
        ///       "firstName": "test3",
        ///       "lastName": "test3",
        ///       "email": "test3",
        ///       "phoneNumber": "test3",
        ///       "role": "test3",
        ///       "status": "test3",
        ///       "profileImageUrl": "test3",
        ///       "bio": "test3"
        ///     }
        ///         
        /// </remarks> 
        /// <response code="200">Warehouse that was updated</response>
        /// <response code="204">No content</response>
        /// <response code="400">Warehouse does not exist</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CreateUpdateWarehouseRequest updateWarehouseRequest)
        {
            try
            {
                var Warehouse = await _warehouseService.GetWarehouseByIdAsync(updateWarehouseRequest.Id);

                if (Warehouse == null) return NotFound(new
                {
                    ErrorMessage = $"Warehouse with id: {updateWarehouseRequest.Id} does not exist"
                }); ;

                await _warehouseService.UpdateWarehouseAsync(updateWarehouseRequest);

                return Ok(updateWarehouseRequest);
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
    }
}
