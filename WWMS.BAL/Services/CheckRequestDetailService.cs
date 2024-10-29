using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequests;
using WWMS.BAL.Models.CheckRequests.Report;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class CheckRequestDetailService : ICheckRequestDetailService
    {
        #region init
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CheckRequestDetailService(
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
        public async Task<List<GetCheckRequestDetailListItemResponse>> GetAllAsync()
        => _mapper.Map<List<GetCheckRequestDetailListItemResponse>>
        (await _unitOfWork.CheckRequestDetails.GetAllEntitiesAsync());

        public async Task<List<GetCheckRequestDetailListItemResponse>> GetAllByReporterNameAsync(string reporterName)
        => _mapper.Map<List<GetCheckRequestDetailListItemResponse>>
        (await _unitOfWork.CheckRequestDetails.GetAllCheckRequestDetailsByReporterNameAsync(reporterName));

        public async Task UpdateCheckRequestDetailAsync(UpdateCheckRequestDetailRequest updateCheckRequestDetailRequest)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(updateCheckRequestDetailRequest.Id);

            if (checkRequestDetail is null || checkRequestDetail.Status.Equals("DISABLED") || checkRequestDetail.DueDate > DateTime.Now)
            {
                throw new Exception("ID not found or overdue or disabled detail");
            }

            checkRequestDetail.WineRoomId = updateCheckRequestDetailRequest.WineRoomId;
            checkRequestDetail.CheckerId = updateCheckRequestDetailRequest.CheckerId;
            checkRequestDetail.Purpose = !string.IsNullOrWhiteSpace(updateCheckRequestDetailRequest.Purpose) ? updateCheckRequestDetailRequest.Purpose : checkRequestDetail.Purpose;
            checkRequestDetail.StartDate = updateCheckRequestDetailRequest.StartDate ?? checkRequestDetail.StartDate;
            checkRequestDetail.DueDate = updateCheckRequestDetailRequest.DueDate ?? checkRequestDetail.DueDate;
            checkRequestDetail.Comments = !string.IsNullOrWhiteSpace(updateCheckRequestDetailRequest.Comments) ? updateCheckRequestDetailRequest.Comments : checkRequestDetail.Comments;

            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            await _unitOfWork.CompleteAsync();
        }

        public async Task CreateCheckRequestDetailAsync(CreateAdditionalCheckRequestDetailRequest createCheckRequestDetailRequest)
        {
            CheckRequestDetail checkRequestDetail = _mapper.Map<CheckRequestDetail>(createCheckRequestDetailRequest);
            checkRequestDetail.Status = "ACTIVE";
            await _unitOfWork.CheckRequestDetails.AddEntityAsync(_mapper.Map<CheckRequestDetail>(createCheckRequestDetailRequest));
            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableCheckRequestDetailAsync(long id)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(id);
            if (checkRequestDetail is null) throw new Exception("Id not found");
            //other business rule ...
            checkRequestDetail.Status = "DISABLED";
            checkRequestDetail.DeletedTime = DateTime.Now;
            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            _unitOfWork.CompleteAsync();
        }

        public async Task<GetCheckRequestDetailViewDetailResponse> GetByIdAsync(long id)
        => _mapper.Map<GetCheckRequestDetailViewDetailResponse>(await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(id));

        public async Task DeleteReportAsync(int detailId)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(detailId);
            if (checkRequestDetail is null) throw new Exception("Id not found");
            //clear all information about the report
            checkRequestDetail.ReportFile = String.Empty;
            checkRequestDetail.ReportDescription = String.IsNullOrEmpty(checkRequestDetail.ReportDescription) ?
            "DISABLED" : "(DISABLED) " + checkRequestDetail.ReportDescription;
            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            _unitOfWork.CompleteAsync();

        }

        public async Task CreateOrUpdateReportAsync(CreateOrUpdateCheckRequestDetailReportRequest request, long detailId)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(detailId);
            if (checkRequestDetail is null) throw new Exception("Id not found");
            //completing fields relating to the report
            checkRequestDetail.ReportDescription = request.ReportDescription;
            checkRequestDetail.ReporterAssigned = request.ReporterAssigned;
            checkRequestDetail.DiscrepanciesFound = request.DiscrepanciesFound;
            checkRequestDetail.ActualQuantity = request.ActualQuantity;
            checkRequestDetail.ReportCode = GenRandomString();
            //TODO: File handling later
            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            _unitOfWork.CompleteAsync();
        }
        private string GenRandomString(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}