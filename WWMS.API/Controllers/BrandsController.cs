using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Brands;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/brands")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly ILogger<BrandsController> _logger;
        private readonly IBrandService _brandService;

        public BrandsController(
            ILogger<BrandsController> logger,
            IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }

        #region Create Brand
        /// <summary>
        /// Add a brand in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "brandName": "Allan Scott"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Brand that was created</returns>
        /// <response code="200">Brand that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [PermissionAuthorize("MANAGER", "STAFF")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateBrandRequest request)
        {
            try
            {
                await _brandService.CreateAsync(request);

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

        #region Gell All Brands
        /// <summary>
        /// Get all brands in the system
        /// </summary>
        /// <returns>A list of all brands</returns>
        /// <response code="200">Return all brands in the system</response>
        /// <response code="400">If no brands are in the system</response>
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
                var result = await _brandService.GetAllAsync();

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
