using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.CheckRequests;
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

            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            _unitOfWork.CompleteAsync();
        }

        public async Task CreateCheckRequestDetailAsync(CreateCheckRequestDetailRequest createCheckRequestDetailRequest)
        {
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
    }
}