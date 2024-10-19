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
    public class CheckRequestService : ICheckRequestService
    {
        #region init
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CheckRequestService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor
            , IEmailService emailService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        private string GenRandomString(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
        #region Implementation services

        public async Task CreateRequestAsync(CreateCheckRequestRequest createCheckRequestRequest)
        {
            //TODO: get the requester info from jwt token
            //? Whether other relation fulfilled 
            CheckRequest newCheckRequest = _mapper.Map<CheckRequest>(createCheckRequestRequest);
            newCheckRequest.RequestCode = GenRandomString();
            newCheckRequest.Status = "ACTIVE";
            newCheckRequest.CreatedTime = DateTime.Now;

            newCheckRequest.CheckRequestDetails = _mapper.Map<List<CheckRequestDetail>>(createCheckRequestRequest.CreateCheckRequestDetailRequests);

            await _unitOfWork.CheckRequests.AddEntityAsync(newCheckRequest);
            await _unitOfWork.CompleteAsync();
        }


        public async Task DisableAsync(long id, DisableCheckRequestRequest request)
        {
            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(id);
            if (checkRequest is null)
            {
                throw new Exception("Cannot find the check request with the provided id");
            }

            checkRequest.Status = "DISABLED";
            checkRequest.Comments = string.IsNullOrEmpty(checkRequest.Comments)
                ? $"Disable Reason: {request.Comments}"
                : $"{checkRequest.Comments}\nDisable Reason: {request.Comments}";

            foreach (CheckRequestDetail detail in checkRequest.CheckRequestDetails)
            {
                detail.Status = "DISABLED";
                _unitOfWork.CheckRequestDetails.UpdateEntity(detail);
            }

            _unitOfWork.CheckRequests.UpdateEntity(checkRequest);

            await _unitOfWork.CompleteAsync();
        }


        public async Task<GetCheckRequestWithDetailsResponse?> GetCheckRequestByIdAsync(long id)
        {
            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(id);
            GetCheckRequestWithDetailsResponse response = _mapper.Map<GetCheckRequestWithDetailsResponse>(checkRequest);
            response.CheckRequestDetails = _mapper.Map<List<GetCheckRequestDetailListItemResponse>>(checkRequest.CheckRequestDetails);
            return response;

        }

        public async Task<List<GetCheckRequestResponse>> GetCheckRequestListAsync()
        {
            var checkRequests = await _unitOfWork.CheckRequests.GetAllEntitiesAsync();

            var getCheckRequestResponses = checkRequests.Select(item =>
            {
                var dto = _mapper.Map<GetCheckRequestResponse>(item);
                dto.NoOfDetails = item.CheckRequestDetails.Count;
                return dto;
            }).ToList();

            return getCheckRequestResponses;
        }


        public async Task UpdateCheckRequestAsync(UpdateCheckRequestRequest updateCheckRequestRequest)
        {
            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(updateCheckRequestRequest.Id);

            if (checkRequest is null || checkRequest.DueDate > DateTime.Now || checkRequest.Status.Equals("DISABLED"))
            {
                throw new Exception("Overdue or disabled or Id not found");
            }

            checkRequest.StartDate = updateCheckRequestRequest.StartDate ?? checkRequest.StartDate;
            checkRequest.DueDate = updateCheckRequestRequest.DueDate ?? checkRequest.DueDate;
            checkRequest.Purpose = !string.IsNullOrEmpty(updateCheckRequestRequest.Purpose)
                ? updateCheckRequestRequest.Purpose
                : checkRequest.Purpose;
            checkRequest.PriorityLevel = !string.IsNullOrEmpty(updateCheckRequestRequest.PriorityLevel)
                ? updateCheckRequestRequest.PriorityLevel
                : checkRequest.PriorityLevel;
            checkRequest.Comments = !string.IsNullOrEmpty(updateCheckRequestRequest.Comments)
                ? updateCheckRequestRequest.Comments
                : checkRequest.Comments;

            checkRequest.UpdatedTime = DateTime.Now;

            _unitOfWork.CheckRequests.UpdateEntity(checkRequest);
            await _unitOfWork.CompleteAsync();
        }



        #endregion

    }
}