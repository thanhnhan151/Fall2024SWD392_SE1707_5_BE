using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Authentications;
using WWMS.BAL.Interfaces;

namespace WWMS.API.Controllers
{

    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/wine-rooms")]
    [ApiController]
    public class WinRoomController : ControllerBase
    {

        #region  init
        private readonly IWineRoomService _wineRoomService;
        private readonly ILogger<WinRoomController> _logger;

        public WinRoomController(
            ILogger<WinRoomController> logger,
            IWineRoomService wineRoomService)
        {
            _logger = logger;
            _wineRoomService = wineRoomService;
        }
        #endregion


        #region get all active
        /// <summary>
        ///Get All ID-WINEID-WINENAME_ROOMID_ROOMANME => SELECTED BOX ON FE 
        /// </summary>
        [HttpGet]
        [PermissionAuthorize("MANAGER")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _wineRoomService.getActiveWineRoomNameResponseAsync();

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