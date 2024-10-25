using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class ReportIORequestService : IReportIORequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReportIORequestService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //public async Task<GetReportIORequest?> GetReportIORequestByIdAsync(long id) => _mapper.Map<GetReportIORequest?>(await _unitOfWork.IIORequestsDetail.GetEntityByIdAsync(id));


        //public async Task<List<GetReportIORequest>> GetReportIORequestListAsync()
        //{

        //    var allReportIORequests = await _unitOfWork.IIORequestsDetail.GetAllEntitiesAsync();

        //    // Lọc danh sách để chỉ lấy những phần tử mà ReportCode không null hoặc empty
        //    var filteredReportIORequests = allReportIORequests
        //        .Where(reportIORequest => !string.IsNullOrEmpty(reportIORequest.ReportCode))
        //        .ToList();


        //    return _mapper.Map<List<GetReportIORequest>>(filteredReportIORequests);
        //}

        //public async Task UpdateReportIORequestAsync(UpdateReportIORequest updateReportIO, string file)
        //{
        //    var currentReportIORequest = await _unitOfWork.IIORequestsDetail.GetEntityByIdAsync(updateReportIO.Id);

        //    if (currentReportIORequest == null)
        //        throw new Exception("IORequestDetails not found.");

        //    // Kiểm tra nếu yêu cầu đã có trạng thái "Done"
        //    if (currentReportIORequest.Status == "Done" || currentReportIORequest.Status == "Cancel")
        //        throw new Exception("This request has already been completed and cannot be modified.");

        //    // Cập nhật thông tin report
        //    currentReportIORequest.ReportCode = !string.IsNullOrEmpty(updateReportIO.ReportCode) ? updateReportIO.ReportCode : currentReportIORequest.ReportCode;
        //    currentReportIORequest.ReportDescription = updateReportIO.ReportDescription ?? currentReportIORequest.ReportDescription;
        //    currentReportIORequest.ReporterAssigned = !string.IsNullOrEmpty(updateReportIO.ReporterAssigned) ? updateReportIO.ReporterAssigned : currentReportIORequest.ReporterAssigned;
        //    currentReportIORequest.DiscrepanciesFound = updateReportIO.DiscrepanciesFound ?? currentReportIORequest.DiscrepanciesFound;
        //    currentReportIORequest.ActualQuantity = updateReportIO.ActualQuantity != default ? updateReportIO.ActualQuantity : currentReportIORequest.ActualQuantity;
        //    currentReportIORequest.ReportFile = !string.IsNullOrEmpty(file) ? file : currentReportIORequest.ReportFile;

        //    _unitOfWork.IIORequestsDetail.UpdateEntity(currentReportIORequest);

        //    // Kiểm tra trạng thái sau khi update và chuyển thành done
        //    var IorequeDetail = await _unitOfWork.IIORequestsDetail.CheckDoneAsync(updateReportIO.Id);
        //    var IorequestFather = await _unitOfWork.IIORequests.GetEntityByIdAsync(IorequeDetail.IORequestId);

        //    // Nhập kho (In)
        //    if (IorequestFather.IOType == "In" && IorequeDetail.Status == "Done")
        //    {
        //        var room = await _unitOfWork.Rooms.GetEntityByIdAsync(currentReportIORequest.RoomId);

        //        if (room.CurrentOccupancy + currentReportIORequest.ActualQuantity <= room.Capacity)
        //        {
        //            room.CurrentOccupancy += currentReportIORequest.ActualQuantity;
        //            _unitOfWork.Rooms.UpdateEntity(room);
        //        }
        //        else
        //        {
        //            IorequeDetail.Status = "InProcess";
        //            _unitOfWork.IIORequestsDetail.UpdateEntity(IorequeDetail);

        //            throw new Exception("The room does not have enough capacity for the additional quantity.");
        //        }
        //    }

        //    // Xuất kho (Out)
        //    if (IorequestFather.IOType == "Out" && IorequeDetail.Status == "Done")
        //    {
        //        var room = await _unitOfWork.Rooms.GetEntityByIdAsync(currentReportIORequest.RoomId);

        //        if (room.CurrentOccupancy >= currentReportIORequest.ActualQuantity)
        //        {
        //            room.CurrentOccupancy -= currentReportIORequest.ActualQuantity;
        //            _unitOfWork.Rooms.UpdateEntity(room);
        //        }
        //        else
        //        {
        //            IorequeDetail.Status = "InProcess";
        //            _unitOfWork.IIORequestsDetail.UpdateEntity(IorequeDetail);

        //            throw new Exception("The room does not have enough quantity for the requested outflow.");
        //        }
        //    }

        //    await _unitOfWork.CompleteAsync();
        //}

        //public async Task DisableReportIORequestsAsync(long id)
        //{
        //    await _unitOfWork.IIORequestsDetail.DisableAsync(id);
        //    await _unitOfWork.CompleteAsync();
        //}
    }
}
