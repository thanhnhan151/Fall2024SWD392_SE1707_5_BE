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
            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase)).Value;
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase)).Value;
            var role = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Role", StringComparison.CurrentCultureIgnoreCase)).Value;

            CheckRequestDetail checkRequestDetail = await _unitOfWork.CheckRequestDetails.GetEntityByIdAsync(request.CheckRequestDetailId);
            if (checkRequestDetail is null)
            {
                throw new Exception("Cannot find the check request detail id ");
            }

            if (DateTime.Now > checkRequestDetail.DueDate)
            {
                throw new Exception("Overdue");
            }
            if(checkRequestDetail.Status == "DISABLED"){
                throw new Exception("Disabled already");
            }
            
            //verify reporter
            if (string.Equals(role, "STAFF") && checkRequestDetail.CheckerId != long.Parse(userId))
            {
                throw new Exception("No verified checker");
            }

            //verify numeric value for quantities

            //0 <= DiscrepanciesFound <= Expected
            if (!(0 <= request.DiscrepanciesFound && request.DiscrepanciesFound <= checkRequestDetail.ExpectedCurrQuantity))
            {
                throw new Exception("Error numeric value for DiscrepanciesFound");
            }
            //0 <= Actual <= Expected - DiscrepanciesFound
            if (!(0 <= request.ActualQuantity && request.ActualQuantity <= checkRequestDetail.ExpectedCurrQuantity - request.DiscrepanciesFound))
            {
                throw new Exception("Error numeric value for ActualQuantity");
            }


            checkRequestDetail.ReportCode = string.IsNullOrEmpty(checkRequestDetail.ReportCode) ? GenRandomString() : checkRequestDetail.ReportCode;
            checkRequestDetail.DiscrepanciesFound = request.DiscrepanciesFound;
            checkRequestDetail.ActualQuantity = request.ActualQuantity;
            checkRequestDetail.ReportDescription = request.ReportDescription;
            checkRequestDetail.ReporterAssigned = userName;
            checkRequestDetail.Status = "COMPLETED";

            WineRoom wineRoom = await _unitOfWork.WineRooms.GetEntityByIdAsync(checkRequestDetail.WineRoomId);
            wineRoom.CurrentQuantity = request.ActualQuantity;

            _unitOfWork.CheckRequestDetails.UpdateEntity(checkRequestDetail);
            _unitOfWork.WineRooms.UpdateEntity(wineRoom);
            await _unitOfWork.CompleteAsync();
        }


    }
}