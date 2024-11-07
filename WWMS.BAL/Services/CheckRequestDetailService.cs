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

            #region Verification
            //verify input date range : valid start - due, fit with fixed main check request, future time ???
            if (!(updateCheckRequestDetailRequest.StartDate <= updateCheckRequestDetailRequest.DueDate && updateCheckRequestDetailRequest.StartDate >= DateTime.Now))
            {
                throw new Exception("Invalid date range");
            }
            //DB touch
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(updateCheckRequestDetailRequest.Id);
            if (checkRequestDetail is null || checkRequestDetail.Status.Equals("DISABLED") || checkRequestDetail.DueDate > DateTime.Now || checkRequestDetail.StartDate.Equals("COMPLETED"))
            {
                throw new Exception("ID not found or overdue or disabled or completed detail");
            }
            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(checkRequestDetail.CheckRequestId);

            //verify date range input fit with the main check request date range ?
            if (
                !(
                    (checkRequest.StartDate <= updateCheckRequestDetailRequest.StartDate && updateCheckRequestDetailRequest.StartDate <= checkRequest.DueDate)
                    &&
                    (checkRequest.StartDate <= updateCheckRequestDetailRequest.DueDate && updateCheckRequestDetailRequest.DueDate <= checkRequest.DueDate)

                )
            )
            {
                throw new Exception("Not fit with current fixed date range of main check request");
            }

            //verify is requester ?
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;
            if (checkRequest.RequesterId != long.Parse(userId)) throw new Exception("Not valid requester");

            //verify duplicate wine room id
            HashSet<long> wineRoomIds = checkRequest.CheckRequestDetails.Select(d => d.WineRoomId).ToHashSet();
            if (wineRoomIds.Contains(updateCheckRequestDetailRequest.WineRoomId))
            {
                throw new Exception("Duplicate wine room in same main check request");
            }

            //verify conflict working date

            Dictionary<DateTime?, DateTime?> existedDateRange = checkRequest.CheckRequestDetails.Where(c => c.CheckerId == updateCheckRequestDetailRequest.CheckerId)
                                    .Select(c => (c.StartDate, c.DueDate)).ToDictionary();
            if (
                existedDateRange.ContainsKey(updateCheckRequestDetailRequest.StartDate)
                || existedDateRange.Values.Contains(updateCheckRequestDetailRequest.DueDate)
            )
            {
                throw new Exception("Conflict working date");
            }
            foreach (KeyValuePair<DateTime?, DateTime?> entry in existedDateRange)
            {
                if (
                    (entry.Key < updateCheckRequestDetailRequest.StartDate
                    && updateCheckRequestDetailRequest.StartDate < entry.Value
                    )
                    ||
                    (entry.Key < updateCheckRequestDetailRequest.DueDate
                    && updateCheckRequestDetailRequest.DueDate < entry.Value
                    )
                )
                {
                    throw new Exception("Conflict working date");
                }
            }


            #endregion
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
            #region verify the create request
            if (checkRequest is null
            || DateTime.Now > checkRequest.DueDate
            || checkRequest.Status == "DISABLED"
            || checkRequest.Status == "COMPLETED"
            )
            {
                throw new Exception("Not valid  request || Overdue to add || Main check request is already disabled or completed");
            }
            if (checkRequest.RequesterId != long.Parse(userId))
            {
                throw new Exception("Not the verified requester");
            }
            //verify duplicate wine room id
            HashSet<long> wineRoomIds = checkRequest.CheckRequestDetails.Select(d => d.WineRoomId).ToHashSet();
            if (wineRoomIds.Contains(createCheckRequestDetailRequest.WineRoomId))
            {
                throw new Exception("Duplicate wine room in same request");
            }

            //verify the daterange with fixed daterange of Main Check Request

            if (
                !(
                    (createCheckRequestDetailRequest.StartDate <= createCheckRequestDetailRequest.DueDate)
                &&

                (createCheckRequestDetailRequest.StartDate > DateTime.Now)
                &&
                (checkRequest.StartDate <= createCheckRequestDetailRequest.StartDate &&
                createCheckRequestDetailRequest.StartDate <= checkRequest.DueDate)
                &&
                (checkRequest.StartDate <= createCheckRequestDetailRequest.DueDate &&
                createCheckRequestDetailRequest.DueDate <= checkRequest.DueDate)
                )
            )
            {
                throw new Exception("Invalid date range");
            }


            //verify conflict working date
            Dictionary<DateTime?, DateTime?> existedDateRange = checkRequest.CheckRequestDetails.Where(c => c.CheckerId == createCheckRequestDetailRequest.CheckerId)
                                                .Select(c => (c.StartDate, c.DueDate)).ToDictionary();
            if (
                existedDateRange.ContainsKey(createCheckRequestDetailRequest.StartDate)
                || existedDateRange.Values.Contains(createCheckRequestDetailRequest.DueDate)
            )
            {
                throw new Exception("Conflict working date");
            }
            foreach (KeyValuePair<DateTime?, DateTime?> entry in existedDateRange)
            {
                if (
                    (entry.Key < createCheckRequestDetailRequest.StartDate
                    && createCheckRequestDetailRequest.StartDate < entry.Value
                    )
                    ||
                    (entry.Key < createCheckRequestDetailRequest.DueDate
                    && createCheckRequestDetailRequest.DueDate < entry.Value
                    )
                )
                {
                    throw new Exception("Conflict working date");
                }
            }


            #endregion

            #region mapping data fields
            CheckRequestDetail checkRequestDetail = _mapper.Map<CheckRequestDetail>(createCheckRequestDetailRequest);

            //map checker name
            User checker = await _unitOfWork.Users.GetEntityByIdAsync(createCheckRequestDetailRequest.CheckerId);
            checkRequestDetail.CheckerName = checker.Username;

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
            #endregion

            await _unitOfWork.CheckRequestDetails.AddEntityAsync(checkRequestDetail);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableCheckRequestDetailAsync(long id)
        {
            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(id);
            if (checkRequestDetail is null || DateTime.Now > checkRequestDetail.DueDate || checkRequestDetail.Status == "COMPLETED" || checkRequestDetail.Status == "DISABLED") throw new Exception("Id not found || Overdue || COMPLETED || DISABLED");

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

        private string GenRandomString(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}