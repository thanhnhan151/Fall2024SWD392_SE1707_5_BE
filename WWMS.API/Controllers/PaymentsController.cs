using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WWMS.BAL.Interfaces;

namespace WWMS.API.Controllers
{
    [ApiVersion(1)]
    [Route("api/v{version:apiVersion}/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IVnPayService _vnPayService;

        public PaymentsController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] CreatePaymentRequest request)
        //{
        //    var url = _vnPayService.CreateUrl(request);

        //    return Ok(url);
        //}

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> PaymentCallBack()
        {
            try
            {
                var response = await _vnPayService.ExecutePayment(Request.Query);

                if (response == null) return Redirect("http://localhost:5173/#/payment/fail");

                if (response.VnPayResponseCode == "00") return Redirect("http://localhost:5173/#/payment/success");

                return Redirect("http://localhost:5173/#/payment/fail");
            }
            catch (Exception)
            {
                return Redirect("http://localhost:5173/#/payment/fail");
            }

        }
    }
}
