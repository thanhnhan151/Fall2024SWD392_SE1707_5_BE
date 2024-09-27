﻿using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.WineCategories;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/wine-categories")]
    [ApiController]
    public class WineCategoriesController : ControllerBase
    {
        private readonly ILogger<WineCategoriesController> _logger;
        private readonly IWineCategoryService _wineCategoryService;

        public WineCategoriesController(
            ILogger<WineCategoriesController> logger,
            IWineCategoryService wineCategoryService)
        {
            _logger = logger;
            _wineCategoryService = wineCategoryService;
        }

        #region Create A Wine Category
        /// <summary>
        /// Add a wine category in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "id": "3",
        ///       "username": "test3",
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
        /// <returns>Wine category that was created</returns>
        /// <response code="200">Wine category that was created</response>
        /// <response code="400">Failed validation</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateWineCategoryRequest createWineCategoryRequest)
        {
            try
            {
                await _wineCategoryService.CreateWineCategoryAsync(createWineCategoryRequest);

                return Ok(createWineCategoryRequest);
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

        #region Gell All Wine Categories
        /// <summary>
        /// Get all wine categories in the system
        /// </summary>
        /// <returns>A list of all wine categories</returns>
        /// <response code="200">Return all wine categories in the system</response>
        /// <response code="400">If no wine categories are in the system</response>
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
                var result = await _wineCategoryService.GetWineCategoryListAsync();

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

        #region Get All Wines By Wine Category Id
        /// <summary>
        /// Get all wines by wine category id in the system
        /// </summary>
        /// <param name="id">Id of the wine category you want to get</param>
        /// <returns>A list of wine</returns>
        /// <response code="200">Return a list of wine in the system</response>
        /// <response code="400">If the list is null</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server</response>
        [HttpGet("{id}/wines")]
        public async Task<IActionResult> GetAllWinesByWineCategoryIdAsync(int id)
        {
            try
            {
                var result = await _wineCategoryService.GetAllWinesByWineCategoryIdAsync(id);

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
                ErrorMessage = $"Wine category with id: {id} does not exist"
            });
        }
        #endregion
    }
}