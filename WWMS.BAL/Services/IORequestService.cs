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
            var user = await _unitOfWork.Users.GetEntityByIdAsync(createIORequest.CheckerId);

            ioRequestEntity.CreatedTime = DateTime.UtcNow;
            ioRequestEntity.UpdatedTime = DateTime.UtcNow;
            ioRequestEntity.Status = "Pending";
            ioRequestEntity.CheckerName = user.Username;


            if (createIORequest.IORequestDetails == null || !createIORequest.IORequestDetails.Any())
            {
                throw new Exception("You forgot to add wine in the IO request part.");
            }


            ioRequestEntity.IORequestDetails = _mapper.Map<List<IORequestDetail>>(createIORequest.IORequestDetails);


            await _unitOfWork.IIORequests.AddEntityAsync(ioRequestEntity);
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
            var currentIORequest = _mapper.Map<GetIORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));
            // var currentIORequest = await _unitOfWork.IIORequests.GetEntityByIdAsync(id);

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
            currentIORequest.Status = "Done";

            if (updateIORequest.UpIORequestDetails != null && updateIORequest.UpIORequestDetails.Any())
            {
                foreach (var newDetail in updateIORequest.UpIORequestDetails)
                {
                    var existingDetail = currentIORequest.IORequestDetails.FirstOrDefault(d => d.Id == newDetail.Id);

                    if (existingDetail != null)
                    {

                        existingDetail.Quantity = newDetail.Quantity != 0 ? newDetail.Quantity : existingDetail.Quantity;
                        existingDetail.WineId = newDetail.WineId != 0 ? newDetail.WineId : existingDetail.WineId;

                        if (currentIORequest.IOType == "Out" && currentIORequest.Status == "Pending")
                        {
                            var midRoom = await _unitOfWork.Rooms.GetByIdNotTrack((long)currentIORequest.RoomId);
                            var midWine = await _unitOfWork.Wines.GetByIdNotTrack(existingDetail.WineId);
                            await UpdateWhenOutPutWineRoom(midRoom, midWine, newDetail);
                        }
                        else if (currentIORequest.IOType == "Int" && currentIORequest.Status == "Pending")
                        {
                            var midRoom = await _unitOfWork.Rooms.GetByIdNotTrack((long)currentIORequest.RoomId);
                            var midWine = await _unitOfWork.Wines.GetByIdNotTrack(existingDetail.WineId);
                            await UpdateOrCreateWineRoom(midRoom, midWine, newDetail);
                        }
                    }
                }
            }
            else
            {
                foreach (var existingDetail in currentIORequest.IORequestDetails)
                {

                    var midRoom = await _unitOfWork.Rooms.GetByIdNotTrack((long)currentIORequest.RoomId);
                    var midWine = await _unitOfWork.Wines.GetByIdNotTrack(existingDetail.WineId);

                    if (currentIORequest.IOType == "Out" && currentIORequest.Status == "Pending")
                    {
                        await UpdateExistingWineRoomsForOutput(midRoom, midWine, existingDetail);
                    }
                    else if (currentIORequest.IOType == "Int" && currentIORequest.Status == "Pending")
                    {
                        await UpdateExistingWineRoomsForInput(midRoom, midWine, existingDetail);
                    }
                }
            }
            var io = _mapper.Map<IORequest?>(currentIORequest);
            _unitOfWork.IIORequests.UpdateEntity(io);
            await _unitOfWork.CompleteAsync();
        }
        private async Task UpdateOrCreateWineRoom(Room midRoom, Wine midWine, UpdateIORequestDetail detail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == detail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {

                existingWineRoom.Import += detail.Quantity;
                existingWineRoom.CurrentQuantity = existingWineRoom.InitialQuantity + existingWineRoom.Import - existingWineRoom.Export;
                if (existingWineRoom.Import > midRoom.Capacity)
                {
                    throw new Exception($"Overstock in room {midRoom.RoomName}, current total: {existingWineRoom.InitialQuantity}, capacity: {midRoom.Capacity}");
                }
                if (existingWineRoom.CurrentQuantity < 0)
                {
                    throw new Exception($"CurrentQuantity: {existingWineRoom.CurrentQuantity} is not Enought)");
                }
            }
            else
            {

                var newWineRoom = new WineRoom
                {
                    RoomId = midRoom.Id,
                    WineId = detail.WineId,
                    Import = detail.Quantity,
                    InitialQuantity = detail.Quantity,
                    CurrentQuantity = detail.Quantity
                };
                midRoom.WineRooms ??= new List<WineRoom>();
                midRoom.WineRooms.Add(newWineRoom);
            }


            midRoom.CurrentOccupancy += detail.Quantity;
            if (midRoom.CurrentOccupancy > midRoom.Capacity)
            {
                throw new Exception($"Room over capacity. Current: {midRoom.CurrentOccupancy}, Capacity: {midRoom.Capacity}");
            }

            //midWine.AvailableStock += detail.Quantity;

            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
        }

        private async Task UpdateWhenOutPutWineRoom(Room midRoom, Wine midWine, UpdateIORequestDetail detail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == detail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {

                existingWineRoom.Export += detail.Quantity;
                existingWineRoom.CurrentQuantity = existingWineRoom.InitialQuantity + existingWineRoom.Import - existingWineRoom.Export;
                if (existingWineRoom.CurrentQuantity < 0)
                {
                    throw new Exception("Not enough stock to fulfill the request.");
                }
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

            //if (midWine.AvailableStock < detail.Quantity)
            //{
            //    throw new Exception("Not enough wine stock.");
            //}

            //midWine.AvailableStock -= detail.Quantity;
            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
        }

        private async Task UpdateExistingWineRoomsForInput(Room midRoom, Wine midWine, GetIORequestDetail existingDetail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == existingDetail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {

                existingWineRoom.Import += existingDetail.Quantity;
                existingWineRoom.CurrentQuantity = existingWineRoom.InitialQuantity + existingWineRoom.Import - existingWineRoom.Export;

                if (existingWineRoom.Import > midRoom.Capacity)
                {
                    throw new Exception($"Overstock in room {midRoom.RoomName}, current total: {existingWineRoom.Import}, capacity: {midRoom.Capacity}");
                }
            }
            else
            {
                //
                var newWineRoom = new WineRoom
                {
                    RoomId = midRoom.Id,
                    WineId = existingDetail.WineId,
                    Import = existingDetail.Quantity,
                    InitialQuantity = existingDetail.Quantity,
                    CurrentQuantity = existingDetail.Quantity
                };
                midRoom.WineRooms ??= new List<WineRoom>();
                midRoom.WineRooms.Add(newWineRoom);
            }


            midRoom.CurrentOccupancy += existingDetail.Quantity;
            if (midRoom.CurrentOccupancy > midRoom.Capacity)
            {
                throw new Exception($"Room over capacity. Current: {midRoom.CurrentOccupancy}, Capacity: {midRoom.Capacity}");
            }

            //midWine.AvailableStock += existingDetail.Quantity;

            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
        }

        private async Task UpdateExistingWineRoomsForOutput(Room midRoom, Wine midWine, GetIORequestDetail existingDetail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == existingDetail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {
                if (existingWineRoom.CurrentQuantity < existingDetail.Quantity)
                {
                    throw new Exception("Not enough stock to fulfill the request.");
                }


                existingWineRoom.Export += existingDetail.Quantity;
                existingWineRoom.CurrentQuantity = existingWineRoom.InitialQuantity + existingWineRoom.Import - existingWineRoom.Export;
            }
            else
            {
                throw new Exception("WineRoom entry not found for this wine and room.");
            }

            midRoom.CurrentOccupancy -= existingDetail.Quantity;
            if (midRoom.CurrentOccupancy < 0)
            {
                throw new Exception("Not enough stock in the room.");
            }

            //if (midWine.AvailableStock < existingDetail.Quantity)
            //{
            //    throw new Exception("Not enough wine stock.");
            //}

            //midWine.AvailableStock -= existingDetail.Quantity;
            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<List<GetIORequest>> GetAllEntitiesByIOStyle(string ioType) => _mapper.Map<List<GetIORequest>>(await _unitOfWork.IIORequests.GetEntitiesByIOStyleAsync(ioType));









    }
}

