using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Rooms;
using WWMS.BAL.Models.WineRoom;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.BAL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomService(
            IUnitOfWork unitOfWork
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateRoomAsync(CreateRoomRequest createRoomRequest)
        {
            if (await _unitOfWork.Rooms.CheckExistRoomName(createRoomRequest.RoomName)) throw new Exception($"Room with name: {createRoomRequest.RoomName} has already existed");

            var room = new Room
            {
                RoomName = createRoomRequest.RoomName,
                LocationAddress = createRoomRequest.LocationAddress,
                Capacity = createRoomRequest.Capacity
            };

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null)
            {
                room.CreatedBy = userName.Value;
                room.ManagerName = userName.Value;
            }

            room.Status = "Active";

            room.CreatedTime = DateTime.Now;

            await _unitOfWork.Rooms.AddEntityAsync(room);

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableRoomAsync(long id)
        {
            await _unitOfWork.Rooms.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetRoomDetailResponse?> GetRoomByIdAsync(long id) => _mapper.Map<GetRoomDetailResponse?>(await _unitOfWork.Rooms.GetEntityByIdAsync(id));

        public async Task<GetRoom?> GetWineRoomByIdAsync(long id) => _mapper.Map<GetRoom?>(await _unitOfWork.Rooms.GetEntityByIdAsync(id));

        public async Task<List<GetRoomResponse>> GetRoomListAsync() => _mapper.Map<List<GetRoomResponse>>(await _unitOfWork.Rooms.GetAllEntitiesAsync());

        public async Task UpdateRoomAsync(long id, UpdateRoomRequest updateRoomRequest)
        {
            var room = await _unitOfWork.Rooms.GetEntityByIdAsync(id) ?? throw new Exception($"Room with id: {id} does not exist");

            if (room.CurrentOccupancy > updateRoomRequest.Capacity) throw new Exception($"Room's capacity is: {updateRoomRequest.Capacity}, but current occupancy is: {room.CurrentOccupancy}. Please take {room.CurrentOccupancy - updateRoomRequest.Capacity} bottles out");

            room.Capacity = updateRoomRequest.Capacity;

            room.LocationAddress = updateRoomRequest.LocationAddress;

            room.ManagerName = updateRoomRequest.ManagerName;

            room.RoomName = updateRoomRequest.RoomName;

            var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (userName != null) room.UpdatedBy = userName.Value;

            room.UpdatedTime = DateTime.Now;

            _unitOfWork.Rooms.UpdateEntity(room);

            await _unitOfWork.CompleteAsync();
        }


    }
}
