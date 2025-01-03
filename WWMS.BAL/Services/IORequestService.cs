﻿using AutoMapper;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.IORequests.IOrequestdetails;
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
            ioRequestEntity.CreatedTime = DateTime.UtcNow;
            ioRequestEntity.UpdatedTime = DateTime.UtcNow;
            ioRequestEntity.Status = "Pending";
            ioRequestEntity.RequestCode = GenRandomString();
 

            if (createIORequest.IORequestDetails == null || !createIORequest.IORequestDetails.Any())
            {
                throw new Exception("You forgot to add wine in the IO request part.");
            }


            var wineIds = createIORequest.IORequestDetails.Select(d => d.WineId).ToList();
            if (wineIds.Distinct().Count() != wineIds.Count)
            {
                throw new Exception("Duplicate wine IDs found in the IO request details.");
            }

            ioRequestEntity.IORequestDetails = _mapper.Map<List<IORequestDetail>>(createIORequest.IORequestDetails);

            await _unitOfWork.IIORequests.AddEntityAsync(ioRequestEntity);
            await _unitOfWork.CompleteAsync();
        }

        private string GenRandomString(int length = 12)
        {
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random random = new();
            return new string(Enumerable.Repeat(validChars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task DisableIORequestsAsync(long id)
        {
            await _unitOfWork.IIORequests.DisableAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetIORequest?> GetIORequestsByIdAsync(long id) => _mapper.Map<GetIORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));

        public async Task<List<GetIORequest>> GetIORequestsListAsync() => _mapper.Map<List<GetIORequest>>(await _unitOfWork.IIORequests.GetAllEntitiesAsync());


        /// hàm này để update từ pending sang done
        public async Task DoneIORequestsAsync(long id)
        {

            var currentIORequest = _mapper.Map<GetIORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));

            if (currentIORequest == null)
            {
                throw new Exception("IORequest not found.");
            }


            if (currentIORequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to proceed.");
            }

            if (currentIORequest.IORequestDetails != null && currentIORequest.IORequestDetails.Any())
            {
                foreach (var existingDetail in currentIORequest.IORequestDetails)
                {
                    var midRoom = await _unitOfWork.Rooms.GetByIdNotTrack((long)currentIORequest.RoomId);
                    var midWine = await _unitOfWork.Wines.GetByIdNotTrack(existingDetail.WineId);


                    if (currentIORequest.IOType == "Out" && currentIORequest.Status == "Pending")
                    {
                        await UpdateExistingWineRoomsForOutput(midRoom, midWine, existingDetail);
                    }
                    else if (currentIORequest.IOType == "In" && currentIORequest.Status == "Pending")
                    {
                        await UpdateExistingWineRoomsForInput(midRoom, midWine, existingDetail);
                    }
                }
            }
            currentIORequest.Status = "Done";

            var io = _mapper.Map<IORequest?>(currentIORequest);
            _unitOfWork.IIORequests.UpdateEntity(io);
            await _unitOfWork.CompleteAsync();
        }


        private async Task UpdateExistingWineRoomsForInput(Room midRoom, Wine midWine, GetIORequestDetail existingDetail)
        {
            var existingWineRoom = midRoom.WineRooms.FirstOrDefault(wr => wr.WineId == existingDetail.WineId && wr.RoomId == midRoom.Id);

            if (existingWineRoom != null)
            {

                existingWineRoom.Import += existingDetail.Quantity;
                existingWineRoom.CurrentQuantity = existingWineRoom.InitialQuantity + existingWineRoom.Import - existingWineRoom.Export;

                if (existingWineRoom.CurrentQuantity > midRoom.Capacity)
                {
                    throw new Exception($"Overstock in room {midRoom.RoomName}, current total: {existingWineRoom.CurrentQuantity}, capacity: {midRoom.Capacity}");
                }
            }
            else
            {
                //
                var newWineRoom = new WineRoom
                {
                    RoomId = midRoom.Id,
                    WineId = existingDetail.WineId,
                    Import = 0,
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
                    throw new Exception($"Not enough stock to fulfill the request, current total: {existingWineRoom.CurrentQuantity}, quantity request: {existingDetail.Quantity}");
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

            _unitOfWork.Rooms.UpdateEntity(midRoom);
            _unitOfWork.Wines.UpdateEntity(midWine);
            await _unitOfWork.CompleteAsync();
        }
        public async Task<List<GetIORequest>> GetAllEntitiesByIOStyle(string ioType) => _mapper.Map<List<GetIORequest>>(await _unitOfWork.IIORequests.GetEntitiesByIOStyleAsync(ioType));

        // fixx
        public async Task UpdateManyIORequestsAsync(UpdateIORequest updateIORequest, long id)
        {
            var currentIORequest = _mapper.Map<IORequest>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));
            currentIORequest.RequestCode = currentIORequest.RequestCode;
            currentIORequest.StartDate = updateIORequest.StartDate ?? currentIORequest.StartDate;
            currentIORequest.Comments = updateIORequest.Comments ?? currentIORequest.Comments;
            currentIORequest.IOType = string.IsNullOrEmpty(updateIORequest.IOType) ? currentIORequest.IOType : updateIORequest.IOType;

            currentIORequest.CheckerId = updateIORequest.CheckerId ?? currentIORequest.CheckerId;
            currentIORequest.CustomerId = updateIORequest.CustomerId ?? currentIORequest.CustomerId;
            currentIORequest.SuplierId = updateIORequest.SuplierId ?? currentIORequest.SuplierId;
            currentIORequest.RoomId = updateIORequest.RoomId ?? currentIORequest.RoomId;
       
            if (currentIORequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to update.");
            }

            foreach (var item in updateIORequest.UpIORequestDetails)
            {
                if (item != null)
                {
                    var existingDetail = currentIORequest.IORequestDetails.FirstOrDefault(d => d.Id == item.Id);
                    if(existingDetail != null)
                    {
                        existingDetail.Quantity = item.Quantity != 0 ? item.Quantity : existingDetail.Quantity;
                        existingDetail.WineId = item.WineId != 0 ? item.WineId : existingDetail.WineId;
                    }
                    
                }
            }

            _unitOfWork.IIORequests.UpdateEntity(currentIORequest);
            await _unitOfWork.CompleteAsync();
        }


        public async Task CreateManyIORequestDetailsByIdAsync(CreateDetailsById updateIORequest, long id)
        {
            var currentIORequest = _mapper.Map<IORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));


            if (currentIORequest == null)
            {
                throw new Exception("IORequest not found.");
            }

            if (currentIORequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to update.");
            }

            if (updateIORequest.IORequestDetails != null && updateIORequest.IORequestDetails.Any())
            {
                foreach (var newDetail in updateIORequest.IORequestDetails)
                {

                    currentIORequest.IORequestDetails.Add(new IORequestDetail
                    {
                        Quantity = newDetail.Quantity,
                        WineId = newDetail.WineId,
                        IORequestId = currentIORequest.Id
                    });

                }
            }
            var io = _mapper.Map<IORequest?>(currentIORequest);
            _unitOfWork.IIORequests.UpdateEntity(io);
            await _unitOfWork.CompleteAsync();
        }


        public async Task UpdateManyIORequestDetailsByIdAsync(UpdateDetailsById updateIORequest, long id)
        {
            var currentIORequest = _mapper.Map<GetIORequest?>(await _unitOfWork.IIORequests.GetEntityByIdAsync(id));

            if (currentIORequest == null)
            {
                throw new Exception("IORequest not found.");
            }
            if (currentIORequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to update.");
            }

            if (updateIORequest.UpIORequestDetails != null && updateIORequest.UpIORequestDetails.Any())
            {
                foreach (var newDetail in updateIORequest.UpIORequestDetails)
                {

                    var existingDetail = currentIORequest.IORequestDetails
                        .FirstOrDefault(d => d.Id == newDetail.Id);

                    if (existingDetail != null)
                    {

                        existingDetail.Quantity = newDetail.Quantity != 0 ? newDetail.Quantity : existingDetail.Quantity;
                        existingDetail.WineId = newDetail.WineId != 0 ? newDetail.WineId : existingDetail.WineId;
                    }
                    else
                    {

                        currentIORequest.IORequestDetails.Add(new GetIORequestDetail
                        {
                            Quantity = newDetail.Quantity,
                            WineId = newDetail.WineId,

                        });
                    }
                }
            }
            var nowIORequest = _mapper.Map<IORequest?>(currentIORequest);
            nowIORequest.UpdatedTime = DateTime.UtcNow;
            _unitOfWork.IIORequests.UpdateEntity(nowIORequest);
            await _unitOfWork.CompleteAsync();
        }

        /// delete one iorequest details 

        public async Task RemoveIORequestDetailByIdAsync(long ioRequestId, long detailId)
        {
            await _unitOfWork.IIORequests.DisableDetailsAsync(ioRequestId, detailId);

            await _unitOfWork.CompleteAsync();
        }


    }
}

