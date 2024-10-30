using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Customers;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;

        public CustomersController(
            ILogger<CustomersController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        #region Create Customer
        /// <summary>
        /// Add a customer in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "customerName": "Trang Thien Bao"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Customer that was created</returns>
        /// <response code="200">Customer that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCustomerRequest request)
        {
            try
            {
                await _customerService.CreateAsync(request);

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

        #region Gell All Customers
        /// <summary>
        /// Get all customers in the system
        /// </summary>
        /// <returns>A list of all customers</returns>
        /// <response code="200">Return all customers in the system</response>
        /// <response code="400">If no customers are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("MANAGER", "STAFF")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _customerService.GetAllAsync();

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
    }
}
