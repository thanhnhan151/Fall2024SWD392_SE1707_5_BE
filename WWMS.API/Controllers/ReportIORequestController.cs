using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.ReportIORequest;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/reports")]
    [ApiController]
    public class ReportIORequestController : ControllerBase
    {
        private readonly ILogger<ReportIORequestController> _logger;
        private readonly IReportIORequestService _reportIORequest;
        private readonly IUploadFileService _uploadFileService;

        public ReportIORequestController(
            ILogger<ReportIORequestController> logger,
            IReportIORequestService reportIORequest,
            IUploadFileService uploadFileService)
        {
            _logger = logger;
            _reportIORequest = reportIORequest;
            _uploadFileService = uploadFileService;
        }

 
    }
}
