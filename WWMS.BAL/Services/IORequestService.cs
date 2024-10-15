using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class IORequestService : IIORequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IORequestService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // cần làm tính tổng sản phẩm : done
        // cần làm chọn file không
        // cần làm xuất file không?
        public async Task CreateIORequestsAsync(CreateIORequest createIORequest)
        {
            var ioRequestEntity = _mapper.Map<IORequest>(createIORequest);
            int quantityMid=0;
            ioRequestEntity.StartDate = DateTime.UtcNow;
            ioRequestEntity.CreatedTime = DateTime.UtcNow;
      
            ioRequestEntity.UpdatedTime = DateTime.UtcNow;

            if (ioRequestEntity.IORequestDetails != null)
            {
                foreach (var detail in createIORequest.IORequestDetails)
                {
                    quantityMid += detail.Quantity;
                    detail.StartDate = DateTime.UtcNow;
              
                    detail.CreatedTime = DateTime.UtcNow; 
                    detail.UpdatedTime = DateTime.UtcNow;
                }
            }
            ioRequestEntity.TotalQuantity = quantityMid;
            ioRequestEntity.IORequestDetails = _mapper.Map<List<IORequestDetail>>(createIORequest.IORequestDetails);

            await _unitOfWork.IIORequests.AddEntityAsync(ioRequestEntity);
            await _unitOfWork.CompleteAsync();
        }


        // update iOREQUEST nếu nhập thiếu  thì sẽ lấy dữ liệu cũ chèn vào  : donne (chưa test)
        // update iOREQUESTdETAILS nếu nhập thiếu  thì sẽ lấy dữ liệu cũ chèn vào  : (chưa test)
        // nghiệp vụ chưa test
        public async Task UpdateIORequestsAsync(UpdateIORequest updateIORequest)
        {
            var currentIORequest = await _unitOfWork.IIORequests.GetEntityByIdAsync(updateIORequest.Id);

            if (currentIORequest == null)
            {
                throw new Exception("IORequest not found.");
            }

            // Nếu không thay đổi thì sẽ lấy dữ liệu cũ điền vào 
            currentIORequest.RequestCode = updateIORequest.RequestCode ?? currentIORequest.RequestCode;
            currentIORequest.StartDate = updateIORequest.StartDate ?? currentIORequest.StartDate;
            currentIORequest.DueDate = updateIORequest.DueDate ?? currentIORequest.DueDate;
            currentIORequest.Comments = updateIORequest.Comments ?? currentIORequest.Comments;
            currentIORequest.IOType = string.IsNullOrEmpty(updateIORequest.IOType) ? currentIORequest.IOType : updateIORequest.IOType;
            currentIORequest.PriorityLevel = string.IsNullOrEmpty(updateIORequest.PriorityLevel) ? currentIORequest.PriorityLevel : updateIORequest.PriorityLevel;
            currentIORequest.RequesterId = updateIORequest.RequesterId != 0 ? updateIORequest.RequesterId : currentIORequest.RequesterId;
            currentIORequest.RequesterName = updateIORequest.RequesterName ?? currentIORequest.RequesterName;
            currentIORequest.UpdatedTime = DateTime.Now;

            if (updateIORequest.UpIORequestDetails != null && updateIORequest.UpIORequestDetails.Any())
            {
                foreach (var newDetail in updateIORequest.UpIORequestDetails)
                {
                    var existingDetail = currentIORequest.IORequestDetails.FirstOrDefault(d => d.Id == newDetail.Id);

                    if (existingDetail != null)
                    {
                        // Nếu không thay đổi thì sẽ lấy dữ liệu cũ điền vào 
                        existingDetail.Quantity = newDetail.Quantity != 0 ? newDetail.Quantity : existingDetail.Quantity;
                        existingDetail.StartDate = newDetail.StartDate ?? existingDetail.StartDate;
                        existingDetail.EndDate = newDetail.EndDate ?? existingDetail.EndDate;
                        existingDetail.Comments = string.IsNullOrEmpty(newDetail.Comments) ? existingDetail.Comments : newDetail.Comments;
                        existingDetail.WineId = newDetail.WineId != 0 ? newDetail.WineId : existingDetail.WineId;
                        existingDetail.Supplier = string.IsNullOrEmpty(newDetail.Supplier) ? existingDetail.Supplier : newDetail.Supplier;
                        existingDetail.WineName = string.IsNullOrEmpty(newDetail.WineName) ? existingDetail.WineName : newDetail.WineName;
                        existingDetail.MFD = newDetail.MFD ?? existingDetail.MFD;
                        existingDetail.RoomId = newDetail.RoomId != 0 ? newDetail.RoomId : existingDetail.RoomId;
                        existingDetail.RoomName = string.IsNullOrEmpty(newDetail.RoomName) ? existingDetail.RoomName : newDetail.RoomName;
                        existingDetail.IORequestCode = string.IsNullOrEmpty(newDetail.IORequestCode) ? existingDetail.IORequestCode : newDetail.IORequestCode;
                        existingDetail.CheckerId = newDetail.CheckerId != 0 ? newDetail.CheckerId : existingDetail.CheckerId;
                        existingDetail.CheckerName = string.IsNullOrEmpty(newDetail.CheckerName) ? existingDetail.CheckerName : newDetail.CheckerName;

                        // Tự nhập tay
                        existingDetail.WineRoomId = newDetail.WineRoomId != 0 ? newDetail.WineRoomId : existingDetail.WineRoomId;

                        // Cập nhật thông tin báo cáo
                        existingDetail.ReportCode = string.IsNullOrEmpty(newDetail.ReportCode) ? existingDetail.ReportCode : newDetail.ReportCode;
                        existingDetail.ReportDescription = string.IsNullOrEmpty(newDetail.ReportDescription) ? existingDetail.ReportDescription : newDetail.ReportDescription;
                        existingDetail.ReporterAssigned = string.IsNullOrEmpty(newDetail.ReporterAssigned) ? existingDetail.ReporterAssigned : newDetail.ReporterAssigned;
                        existingDetail.DiscrepanciesFound = newDetail.DiscrepanciesFound ?? existingDetail.DiscrepanciesFound;
                        existingDetail.ActualQuantity = newDetail.ActualQuantity != 0 ? newDetail.ActualQuantity : existingDetail.ActualQuantity;
                        existingDetail.ReportFile = string.IsNullOrEmpty(newDetail.ReportFile) ? existingDetail.ReportFile : newDetail.ReportFile;

                        // Cập nhật thời gian
                        existingDetail.UpdatedTime = DateTime.Now;
                    }
                }
            }

            // Tính toán tổng số lượng từ cả các chi tiết đã sửa đổi và các chi tiết còn lại trong cơ sở dữ liệu
            currentIORequest.TotalQuantity = currentIORequest.IORequestDetails.Sum(d => d.Quantity);

            _unitOfWork.IIORequests.UpdateEntity(currentIORequest);
            await _unitOfWork.CompleteAsync();
        }


        public async Task DisableIORequestsAsync(long id)
        {
            await _unitOfWork.IIORequests.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetIORequest?> GetIORequestsByIdAsync(long id) => _mapper.Map<GetIORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));

        public async Task<List<GetIORequest>> GetIORequestsListAsync() => _mapper.Map<List<GetIORequest>>(await _unitOfWork.IIORequests.GetAllEntitiesAsync());
    }
}
