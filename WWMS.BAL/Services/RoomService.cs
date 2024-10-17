using AutoMapper;
using Microsoft.AspNetCore.Http;
using WWMS.BAL.Interfaces;
using WWMS.BAL.Models.Rooms;
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

            var managerName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

            if (managerName != null)
            {
                room.CreatedBy = managerName.Value;

                room.ManagerName = managerName.Value;
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

        public async Task<List<GetRoomResponse>> GetRoomListAsync() => _mapper.Map<List<GetRoomResponse>>(await _unitOfWork.Rooms.GetAllEntitiesAsync());

        public async Task UpdateRoomAsync(UpdateRoomRequest updateRoomRequest)
        {
            _unitOfWork.Rooms.UpdateEntity(_mapper.Map<Room>(updateRoomRequest));

            await _unitOfWork.CompleteAsync();
        }
    }
}
