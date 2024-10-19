using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/check-request-details")]
    [ApiController]
    public class CheckRequestDetailController : ControllerBase
    {
        private readonly ILogger<CheckRequestController> _logger;
        private readonly ICheckRequestDetailService _checkRequestDetailService;

        public CheckRequestDetailController(
            ILogger<CheckRequestController> logger,
            ICheckRequestDetailService checkRequestDetailService)
        {
            _logger = logger;
            _checkRequestDetailService = checkRequestDetailService;

        }

        
    }
}