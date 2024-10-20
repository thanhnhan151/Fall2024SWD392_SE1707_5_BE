using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.Rooms;
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




        public async Task CreateIORequestsAsync(CreateIORequest createIORequest)
        {
            var ioRequestEntity = _mapper.Map<IORequest>(createIORequest);
            var midRoom = await _unitOfWork.Rooms.GetByIdNotTrack(ioRequestEntity.RoomId);
            var user = await _unitOfWork.Users.GetEntityByIdAsync(createIORequest.CheckerId);
            int quantityMid = 0;
            ioRequestEntity.CreatedTime = DateTime.UtcNow;
            ioRequestEntity.UpdatedTime = DateTime.UtcNow;
            ioRequestEntity.Status = "Active";
            ioRequestEntity.CheckerName = user.Username;
            if (ioRequestEntity.IOType == "In" || ioRequestEntity.IOType == "Out")
            {
                if (ioRequestEntity.IORequestDetails != null)
                {
                    foreach (var detail in createIORequest.IORequestDetails)
                    {
                        quantityMid += detail.Quantity;
                      //  detail.CreatedTime = DateTime.UtcNow;
                      //  detail.UpdatedTime = DateTime.UtcNow;

                       
                        var midWine = await _unitOfWork.Wines.GetEntityByIdAsync(detail.WineId);

                        if (ioRequestEntity.IOType == "In")
                        {
                            // Xử lý khi IOType là "In"
                            int wineQuantity = (int)midWine.AvailableStock + detail.Quantity;
                            int roomQuantity = (int)midRoom.CurrentOccupancy + detail.Quantity;

                            var wi = new WineRoom()
                            {
                                RoomId = midRoom.Id,
                                WineId = detail.WineId,
                                TotalQuantity = detail.Quantity,
                                CurrentQuantity = (int)midWine.AvailableStock + detail.Quantity
                            };

                            midRoom.WineRooms.Add(wi);
                            midRoom.CurrentOccupancy = roomQuantity;
                            _unitOfWork.Rooms.UpdateEntity(midRoom);
                            await _unitOfWork.CompleteAsync();


                            midWine.AvailableStock = wineQuantity;
                            _unitOfWork.Wines.UpdateEntity(midWine);
                            await _unitOfWork.CompleteAsync();
                        }
                        else if (ioRequestEntity.IOType == "Out")
                        {
                    
                            int wineQuantity = (int)midWine.AvailableStock - detail.Quantity;
                            int roomQuantity = (int)midRoom.CurrentOccupancy - detail.Quantity;

                            if (wineQuantity < 0 || roomQuantity < 0)
                            {
                                throw new Exception("Not enough stock in either the wine or the room.");
                            }


                            midWine.AvailableStock = wineQuantity;
                            _unitOfWork.Wines.UpdateEntity(midWine);
                            await _unitOfWork.CompleteAsync();


                            midRoom.CurrentOccupancy = roomQuantity;
                            _unitOfWork.Rooms.UpdateEntity(midRoom);
                            await _unitOfWork.CompleteAsync();
                        }


        
                    }
                }


                ioRequestEntity.IORequestDetails = _mapper.Map<List<IORequestDetail>>(createIORequest.IORequestDetails);

                await _unitOfWork.IIORequests.AddEntityAsync(ioRequestEntity);
                await _unitOfWork.CompleteAsync();
            }
        }



        public async Task DisableIORequestsAsync(long id)
        {
            await _unitOfWork.IIORequests.DisableAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetIORequest?> GetIORequestsByIdAsync(long id) => _mapper.Map<GetIORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));

        public async Task<List<GetIORequest>> GetIORequestsListAsync() => _mapper.Map<List<GetIORequest>>(await _unitOfWork.IIORequests.GetAllEntitiesAsync());

        public async Task UpdateIORequestsAsync(UpdateIORequest updateIORequest, long id)
        {
            var currentIORequest = await _unitOfWork.IIORequests.GetEntityByIdAsync(id);

            if (currentIORequest == null)
            {
                throw new Exception("IORequest not found.");
            }


            currentIORequest.RequestCode = updateIORequest.RequestCode ?? currentIORequest.RequestCode;
            currentIORequest.StartDate = updateIORequest.StartDate ?? currentIORequest.StartDate;
            currentIORequest.DueDate = updateIORequest.DueDate ?? currentIORequest.DueDate;
            currentIORequest.Comments = updateIORequest.Comments ?? currentIORequest.Comments;
            currentIORequest.IOType = string.IsNullOrEmpty(updateIORequest.IOType) ? currentIORequest.IOType : updateIORequest.IOType;

            currentIORequest.SupplierName = updateIORequest.SupplierName ?? currentIORequest.SupplierName;
            currentIORequest.CustomerName = updateIORequest.CustomerName ?? currentIORequest.CustomerName;
            currentIORequest.RoomId = updateIORequest.RoomId ?? currentIORequest.RoomId;
            currentIORequest.CheckerId = updateIORequest.CheckerId ?? currentIORequest.CheckerId;
            var user = await _unitOfWork.Users.GetEntityByIdAsync((long)currentIORequest.CheckerId);
            currentIORequest.CheckerName = user.Username;
            currentIORequest.Status = updateIORequest.Status ?? currentIORequest.Status;
            currentIORequest.UpdatedTime = DateTime.Now;

            if (updateIORequest.UpIORequestDetails != null && updateIORequest.UpIORequestDetails.Any())
            {
                foreach (var newDetail in updateIORequest.UpIORequestDetails)
                {
                    var existingDetail = currentIORequest.IORequestDetails.FirstOrDefault(d => d.Id == newDetail.Id);

                    if (existingDetail != null)
                    {
                        existingDetail.Quantity = newDetail.Quantity != 0 ? newDetail.Quantity : existingDetail.Quantity;
                        existingDetail.WineId = newDetail.WineId != 0 ? newDetail.WineId : existingDetail.WineId;

                    }
                }
            }

            _unitOfWork.IIORequests.UpdateEntity(currentIORequest);
            await _unitOfWork.CompleteAsync();
        }
    }









    }

