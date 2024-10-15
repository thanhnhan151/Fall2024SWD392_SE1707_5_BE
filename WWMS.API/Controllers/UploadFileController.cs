using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Services;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/upload")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly ILogger<UploadFileController> _logger;
        private readonly IUploadFileService _uploadFileService;

        public UploadFileController(
            ILogger<UploadFileController> logger,
            IUploadFileService uploadFileService)
        {
            _logger = logger;
            _uploadFileService = uploadFileService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage( IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { ErrorMessage = "No file uploaded" });
            }

            try
            {
                var downloadUrl = await _uploadFileService.UploadImage(file);
                return Ok(new { DownloadUrl = downloadUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}
