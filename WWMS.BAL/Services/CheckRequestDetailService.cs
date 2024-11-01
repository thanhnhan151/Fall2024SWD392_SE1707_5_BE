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
        {
            var userRole = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("role", StringComparison.CurrentCultureIgnoreCase)).Value;

            if (string.Equals(userRole, "MANAGER"))
            {
                return _mapper.Map<List<GetCheckRequestDetailListItemResponse>>
                     (await _unitOfWork.CheckRequestDetails.GetAllEntitiesAsync());
            }
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;
            return _mapper.Map<List<GetCheckRequestDetailListItemResponse>>
                     (await _unitOfWork.CheckRequestDetails.GetAllByChecKerIdAsync(long.Parse(userId)));
        }

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
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;
            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(createCheckRequestDetailRequest.CheckRequestId);
            if (checkRequest is null
            || checkRequest.RequesterId != long.Parse(userId)
            || checkRequest.StartDate > createCheckRequestDetailRequest.StartDate
            || checkRequest.DueDate < createCheckRequestDetailRequest.DueDate)
            {
                throw new Exception("Not valid requester || request || date time range");
            }

            CheckRequestDetail checkRequestDetail = _mapper.Map<CheckRequestDetail>(createCheckRequestDetailRequest);

            checkRequestDetail.Status = "ACTIVE";
            checkRequestDetail.CreatedTime = DateTime.Now;
            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase)).Value;
            checkRequestDetail.CreatedBy = userName;

            //wine room
            WineRoom wineRoom = await _unitOfWork.WineRooms.GetEntityByIdWithWRInfoAsync(createCheckRequestDetailRequest.WineRoomId);

            checkRequestDetail.ExpectedCurrQuantity = wineRoom.CurrentQuantity;
            //wine
            checkRequestDetail.WineName = wineRoom.Wine.WineName;
            checkRequestDetail.MFD = wineRoom.Wine.MFD;
            checkRequestDetail.WineId = wineRoom.WineId;
            //room
            checkRequestDetail.RoomId = wineRoom.RoomId;
            checkRequestDetail.RoomName = wineRoom.Room.RoomName;
            checkRequestDetail.RoomCapacity = (int)wineRoom.Room.Capacity;

            await _unitOfWork.CheckRequestDetails.AddEntityAsync(checkRequestDetail);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableCheckRequestDetailAsync(long id)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(id);
            if (checkRequestDetail is null || DateTime.Now > checkRequestDetail.DueDate) throw new Exception("Id not found || Overdue");

            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(checkRequestDetail.CheckRequestId);

            //compare requester
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;
            if (checkRequest.RequesterId != long.Parse(userId)) throw new Exception("Not valid requester");

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase)).Value;

            checkRequestDetail.Status = "DISABLED";
            checkRequestDetail.DeletedTime = DateTime.Now;
            checkRequestDetail.DeletedBy = userName;

            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            _unitOfWork.CompleteAsync();
        }

        public async Task<GetCheckRequestDetailViewDetailResponse> GetByIdAsync(long id)
        {
            GetCheckRequestDetailViewDetailResponse response = _mapper.Map<GetCheckRequestDetailViewDetailResponse>(await _unitOfWork.CheckRequestDetails.GetByIdWithCheckRequestAsync(id));
            var role = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Role", StringComparison.CurrentCultureIgnoreCase)).Value;
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;
            if (string.Equals(role, "MANAGER") || response.CheckerId == long.Parse(userId))
            {
                return response;
            }
            throw new Exception("NO VERIFIED USER");
        }

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