﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using WWMS.BAL.Helpers;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.VnPays;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly VnPayConfig _vnPayConfig;

        public VnPayService(
            IHttpContextAccessor httpContextAccessor
            , IOptions<VnPayConfig> vnPayConfigOptions
            , IUnitOfWork unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
            _vnPayConfig = vnPayConfigOptions.Value;
            _unitOfWork = unitOfWork;
        }

        public string CreateUrl(CreatePaymentRequest request)
        {
            var ipAddress = _httpContextAccessor?.HttpContext?.Connection?.LocalIpAddress?.ToString();

            var paymentUrl = string.Empty;

            var vnPayRequest = new VnPayRequest(
                _vnPayConfig.Version,
                _vnPayConfig.TmnCode,
                DateTime.Now,
                ipAddress ?? string.Empty,
                request.RequiredAmount ?? 0,
                "other",
                request.PaymentContent ?? string.Empty,
                _vnPayConfig.ReturnUrl,
                "123456789");

            paymentUrl = vnPayRequest.GetLink(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);

            return paymentUrl;
        }

        public async Task<string> CreateUrl(int id)
        {
            var ipAddress = _httpContextAccessor?.HttpContext?.Connection?.LocalIpAddress?.ToString();

            var paymentUrl = string.Empty;

            var sum = await _unitOfWork.IIORequests.GetImportRequestPriceForPaymentAsync(id);

            var vnPayRequest = new VnPayRequest(
            _vnPayConfig.Version,
            _vnPayConfig.TmnCode,
            DateTime.Now,
            ipAddress ?? string.Empty,
            (int)sum,
            "other",
            $"Check-out import request {id}" ?? string.Empty,
            _vnPayConfig.ReturnUrl,
            id.ToString());

            paymentUrl = vnPayRequest.GetLink(_vnPayConfig.PaymentUrl, _vnPayConfig.HashSecret);

            return paymentUrl;
        }

        public async Task<VnPayResponse> ExecutePayment(IQueryCollection collections)
        {
            var vnPayLibrary = new VnPayLibrary();
            foreach (var (key, value) in collections)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnPayLibrary.AddResponseData(key, value.ToString());
                }
            }

            var vnp_OrderId = Convert.ToInt64(vnPayLibrary.GetResponseData("vnp_TxnRef"));
            var vnp_TransactionId = Convert.ToInt64(vnPayLibrary.GetResponseData("vnp_TransactionNo"));
            var vnp_SecureHash = collections.FirstOrDefault(p => p.Key == "vnp_SecureHash").Value;
            var vnp_ResponseCode = vnPayLibrary.GetResponseData("vnp_ResponseCode");
            var vnp_OrderInfo = vnPayLibrary.GetResponseData("vnp_OrderInfo");
            var vnp_Amount = Convert.ToInt64(vnPayLibrary.GetResponseData("vnp_Amount"));

            if (vnp_ResponseCode.Equals("00"))
            {
                var import = await _unitOfWork.IIORequests.GetEntityByIdAsync((int)vnp_OrderId);

                if (import != null)
                {
                    import.Status = "Delivered";

                    _unitOfWork.IIORequests.UpdateEntity(import);

                    await _unitOfWork.CompleteAsync();
                }
            }

            bool checkSignature = vnPayLibrary.ValidateSignature(vnp_SecureHash, _vnPayConfig.HashSecret);
            if (!checkSignature)
            {
                return new VnPayResponse
                {
                    Success = false
                };
            }

            return new VnPayResponse
            {
                Success = true,
                PaymentMethod = "VnPay",
                OrderDescription = vnp_OrderInfo,
                OrderId = vnp_OrderId.ToString(),
                TransactionId = vnp_TransactionId.ToString(),
                Token = vnp_SecureHash,
                VnPayResponseCode = vnp_ResponseCode,
                Amount = vnp_Amount
            };
        }
    }
}
