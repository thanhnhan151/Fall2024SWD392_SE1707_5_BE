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
            , IHttpContextAccessor httpContextAccessor)
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
            await _unitOfWork.CheckRequests.AddEntityAsync(await MapCreateModelToCheckRequest(createCheckRequestRequest));
            await _unitOfWork.CompleteAsync();
        }
        private async Task<CheckRequest> MapCreateModelToCheckRequest(CreateCheckRequestRequest createCheckRequestRequest)
        {
            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase)).Value;
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;

            CheckRequest checkRequest = _mapper.Map<CheckRequest>(createCheckRequestRequest);
            checkRequest.RequestCode = GenRandomString();
            checkRequest.Status = "ACTIVE";
            checkRequest.CreatedTime = DateTime.Now;
            checkRequest.CreatedBy = userName;
            checkRequest.RequesterId = long.Parse(userId);
            checkRequest.RequesterName = userName;


            checkRequest.CheckRequestDetails = _mapper.Map<List<CheckRequestDetail>>(createCheckRequestRequest.CreateCheckRequestDetailRequests);

            #region verify the request
            //verify duplicate wineroomid
            List<long> wineRoomIds = createCheckRequestRequest.CreateCheckRequestDetailRequests.Select(d => d.WineRoomId).ToList();
            if (new HashSet<long>(wineRoomIds).Count < wineRoomIds.Count) throw new Exception("Duplicate wine room id");

            //verify busy checker
            var checkerDateRangeMap = new Dictionary<long, Dictionary<DateTime, DateTime>>();
            var comparatorSizeDateRanges = new Dictionary<long, int>();
            //inserting all
            foreach (var item in checkRequest.CheckRequestDetails)
            {
                if (item.StartDate <= DateTime.Now)
                {
                    throw new Exception("Future time required!");
                }

                if (item.StartDate > item.DueDate)
                {
                    throw new Exception("Invalid date range, correct pattern: start date < due date");
                }
                if (checkerDateRangeMap.ContainsKey(item.CheckerId))
                {
                    checkerDateRangeMap[item.CheckerId].Add((DateTime)item.StartDate, (DateTime)item.DueDate);
                    comparatorSizeDateRanges[item.CheckerId] += 2;
                }
                else
                {
                    //add new
                    Dictionary<DateTime, DateTime> checkerDateRangeAdded = new Dictionary<DateTime, DateTime>();
                    checkerDateRangeAdded.Add((DateTime)item.StartDate, (DateTime)item.DueDate);
                    checkerDateRangeMap.Add(item.CheckerId, checkerDateRangeAdded);
                    comparatorSizeDateRanges.Add(item.CheckerId, 2);
                }
            }

            //check size if found throw exception
            foreach (var checker in checkerDateRangeMap.Keys)
            {
                if (
                    (checkerDateRangeMap[checker].Keys.Count + checkerDateRangeMap[checker].Values.Count)
                    != comparatorSizeDateRanges[checker]
                )
                {
                    throw new Exception("Conflict working date with checker: " + checker);
                }
            }

            var CheckerHasMoreThan2Selected = checkerDateRangeMap.Where(c => c.Value.Count > 1)
                                                .ToDictionary(c => c.Key, c => c.Value);


            foreach (var checker in CheckerHasMoreThan2Selected.Keys)
            {
                //verify start date
                foreach (var checkedStart in CheckerHasMoreThan2Selected[checker].Keys)
                {
                    foreach (var comparator in CheckerHasMoreThan2Selected[checker].Keys)
                    {
                        if (comparator < checkedStart)
                        {
                            //check due date
                            if (checkedStart < CheckerHasMoreThan2Selected[checker][comparator])
                            {
                                throw new Exception("Conflict working date range: " + comparator + " -> " + CheckerHasMoreThan2Selected[checker][comparator] + "with checker id: " + checker);
                            }
                        }
                    }
                }
                //verify due date
                foreach (var checkDue in CheckerHasMoreThan2Selected[checker].Values)
                {
                    foreach (var comparator in CheckerHasMoreThan2Selected[checker].Values)
                    {
                        if (comparator > checkDue)
                        {
                            //check start date
                            var checkstartDate = CheckerHasMoreThan2Selected[checker].FirstOrDefault(d => d.Value == comparator).Key;
                            if (checkDue > checkstartDate)
                            {
                                throw new Exception("Conflict working date range: " + checkstartDate + " -> " + comparator + "with checker id: " + checker);
                            }
                        }
                    }
                }

            }
            #endregion


            //get the start/end date for main check request by the min/max start date/end date
            DateTime? mainStartDate = DateTime.MaxValue;
            DateTime? mainDueDate = DateTime.MinValue;

            foreach (var item in checkRequest.CheckRequestDetails)
            {
                //map other fields


                item.Status = "ACTIVE";
                item.CheckRequestCode = checkRequest.RequestCode;
                User checker = await _unitOfWork.Users.GetEntityByIdAsync(item.CheckerId);
                item.CheckerName = checker.Username;

                //wine room
                WineRoom wineRoom = await _unitOfWork.WineRooms.GetEntityByIdWithWRInfoAsync(item.WineRoomId);
                item.ExpectedCurrQuantity = wineRoom.CurrentQuantity;
                //wine
                item.WineName = wineRoom.Wine.WineName;
                item.MFD = wineRoom.Wine.MFD;
                item.WineId = wineRoom.WineId;
                //room
                item.RoomId = wineRoom.RoomId;
                item.RoomName = wineRoom.Room.RoomName;
                item.RoomCapacity = (int)wineRoom.Room.Capacity;


                if (item.StartDate <= mainStartDate)
                {
                    mainStartDate = item.StartDate;
                }

                if (item.DueDate >= mainDueDate)
                {
                    mainDueDate = item.DueDate;
                }
            }
            checkRequest.StartDate = mainStartDate;
            checkRequest.DueDate = mainDueDate;
            return checkRequest;

        }

        public async Task DisableAsync(long id)
        {
            CheckRequest checkRequest = await _unitOfWork.CheckRequests.GetEntityByIdAsync(id);
            if (checkRequest is null || checkRequest.Status.Equals("DISABLED") || checkRequest.Status.Equals("COMPLETED") || checkRequest.DueDate < DateTime.Now)
            {
                throw new Exception("Cannot find the check request with the provided id OR already DISABLED/COMPLETED or Overdue to disable");
            }
            //Auth rule
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;

            if (checkRequest.RequesterId != long.Parse(userId)) throw new Exception("Fail to verify requester with current user");

            //Business rule

            //rule_01: overdue one cannot be disabled anymore
            if (checkRequest.DueDate < DateTime.Now) throw new Exception("Overdue cannot be disabled anymore");

            checkRequest.Status = "DISABLED";
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

            if (checkRequest is null || checkRequest.DueDate < DateTime.Now || checkRequest.Status.Equals("DISABLED") || checkRequest.Status.Equals("COMPLETED"))
            {
                throw new Exception("Overdue or disabled/completed or Id not found");
            }

            //Business rules:

            //Auth for requester
            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase)).Value;
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;

            if (checkRequest.RequesterId != long.Parse(userId)) throw new Exception("Fail to verify requester with current user");

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
            checkRequest.UpdatedBy = userName;

            _unitOfWork.CheckRequests.UpdateEntity(checkRequest);
            await _unitOfWork.CompleteAsync();
        }



        #endregion

    }
}