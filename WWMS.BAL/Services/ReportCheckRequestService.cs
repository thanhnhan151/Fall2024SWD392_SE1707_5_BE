using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequestReports;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class ReportCheckRequestService : IReportCheckRequestService
    {

        #region init
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ReportCheckRequestService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
             )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion


        private string GenRandomString(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task CreateCheckRequestReportAsync(CreateCheckRequestReportRequest request)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(request.CheckRequestDetailId);
            if (checkRequestDetail is null || !String.IsNullOrEmpty(checkRequestDetail.ReportCode))
            {
                throw new Exception("Cannot find the check request detail id OR report existed please update instead");
            }
            checkRequestDetail.ReportCode = GenRandomString();
            checkRequestDetail.DiscrepanciesFound = request.DiscrepanciesFound;
            checkRequestDetail.ActualQuantity = request.ActualQuantity;
            //TODO: Implement file upload for report later
            checkRequestDetail.ReportFile = request.ReportFile;

            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetCheckRequestReportResponse> GetReportByCheckRequestDetailIdAsync(int id)
        => _mapper.Map<GetCheckRequestReportResponse>(await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(id));

        public async Task UpdateCheckRequestReportAsync(UpdateCheckRequestReportRequest request)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(request.CheckRequestDetailId);
            if (checkRequestDetail is null || String.IsNullOrEmpty(checkRequestDetail.ReportCode))
            {
                throw new Exception("Cannot find the check request detail id OR report code");
            }
            checkRequestDetail.ReportCode = GenRandomString();
            checkRequestDetail.DiscrepanciesFound = request.DiscrepanciesFound;
            checkRequestDetail.ActualQuantity = request.ActualQuantity;
            //TODO: Implement file upload for report later
            checkRequestDetail.ReportFile = request.ReportFile;

            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            await _unitOfWork.CompleteAsync();
        }
    }
}