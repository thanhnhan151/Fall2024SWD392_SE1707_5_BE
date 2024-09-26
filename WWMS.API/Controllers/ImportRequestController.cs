using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.ImportRequest;

namespace WWMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportRequestController : ControllerBase
    {
        private readonly ILogger<ImportRequestController> _logger;
        private readonly IImportRequestService _importService;

        public ImportRequestController(ILogger<ImportRequestController> logger, IImportRequestService importService)
        {
            _logger = logger;
            _importService = importService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _importService.GetImportRequestAsync();

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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                var result = await _importService.GetImportRequestByIdAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateImportRequest createImport)
        {
            try
            {
                await _importService.CreateImportRequestAnync(createImport);

                return Ok(createImport);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
