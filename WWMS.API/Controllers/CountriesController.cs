using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Countries;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountryService _countryService;

        public CountriesController(
            ILogger<CountriesController> logger,
            ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        #region Create Country
        /// <summary>
        /// Add a country in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "countryName": "Argentina"
        ///     }
        ///         
        /// </remarks> 
        /// <returns>Country that was created</returns>
        /// <response code="200">Country that was created</response>
        /// <response code="400">Failed Validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Manager", "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCountryRequest request)
        {
            try
            {
                await _countryService.CreateAsync(request);

                return Ok(request);
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

        #region Gell All Countries
        /// <summary>
        /// Get all countries in the system
        /// </summary>
        /// <returns>A list of all countries</returns>
        /// <response code="200">Return all countries in the system</response>
        /// <response code="400">If no countries are in the system</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        //[PermissionAuthorize("Manager", "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _countryService.GetAllAsync();

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
