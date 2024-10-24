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




        //TODO : get the requester infor from jwt token

        public async Task CreateIORequestsAsync(CreateIORequest createIORequest)
        {
            var ioRequestEntity = _mapper.Map<IORequest>(createIORequest);
            var midRoom = await _unitOfWork.Rooms.GetByIdNotTrack(ioRequestEntity.RoomId);
            var user = await _unitOfWork.Users.GetEntityByIdAsync(createIORequest.CheckerId);
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


                        var midWine = await _unitOfWork.Wines.GetEntityByIdAsync(detail.WineId);

                        if (ioRequestEntity.IOType == "In")
                        {
                            await UpdateOrCreateWineRoom(midRoom, midWine, detail);
                        }
                        else if (ioRequestEntity.IOType == "Out")
                        {

                            await UpdateWhenOutPutWineRoom(midRoom, midWine, detail);
                        }
                    }
                }

                ioRequestEntity.IORequestDetails = _mapper.Map<List<IORequestDetail>>(createIORequest.IORequestDetails);
                await _unitOfWork.IIORequests.AddEntityAsync(ioRequestEntity);
                await _unitOfWork.CompleteAsync();
            }
        }



        private async Task UpdateOrCreateWineRoom(Room midRoom, Wine midWine, CreateIORequestDetail detail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == detail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {
                // existingWineRoom.InitialQuantity += detail.Quantity;
                existingWineRoom.InitialQuantity = 0;
                existingWineRoom.CurrentQuantity += detail.Quantity;

                if (existingWineRoom.CurrentQuantity > midRoom.Capacity)
                {
                    throw new Exception($"Overstock in room {midRoom.RoomName}, current total: {existingWineRoom.InitialQuantity}, capacity: {midRoom.Capacity}");
                }
            }
            else
            {
                var newWineRoom = new WineRoom
                {
                    RoomId = midRoom.Id,
                    WineId = detail.WineId,
                    // InitialQuantity = detail.Quantity,
                    InitialQuantity = 0,
                    CurrentQuantity = (int)midWine.AvailableStock + detail.Quantity
                };
                midRoom.WineRooms ??= new List<WineRoom>();
                midRoom.WineRooms.Add(newWineRoom);
            }


            midRoom.CurrentOccupancy += detail.Quantity;
            if (midRoom.CurrentOccupancy > midRoom.Capacity)
            {
                throw new Exception($"Room over capacity. Current: {midRoom.CurrentOccupancy}, Capacity: {midRoom.Capacity}");
            }

            midWine.AvailableStock += detail.Quantity;

            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
        }

        private async Task UpdateWhenOutPutWineRoom(Room midRoom, Wine midWine, CreateIORequestDetail detail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == detail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {
                if (existingWineRoom.CurrentQuantity < detail.Quantity)
                {
                    throw new Exception("Not enough stock to fulfill the request.");
                }

                // existingWineRoom.InitialQuantity -= detail.Quantity;
                existingWineRoom.InitialQuantity = 0;
                existingWineRoom.CurrentQuantity -= detail.Quantity;
            }
            else
            {
                throw new Exception("WineRoom entry not found for this wine and room.");
            }

            midRoom.CurrentOccupancy -= detail.Quantity;
            if (midRoom.CurrentOccupancy < 0)
            {
                throw new Exception("Not enough stock in the room.");
            }

            if (midWine.AvailableStock < detail.Quantity)
            {
                throw new Exception("Not enough wine stock.");
            }

            midWine.AvailableStock -= detail.Quantity;

            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
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


        public async Task<List<GetIORequest>> GetAllEntitiesByIOStyle(string ioType) => _mapper.Map<List<GetIORequest>>(await _unitOfWork.IIORequests.GetEntitiesByIOStyleAsync(ioType));









    }
}

