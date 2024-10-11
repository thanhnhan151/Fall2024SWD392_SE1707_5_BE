using AutoMapper;
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

        public RoomService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateRoomAsync(CreateRoomRequest createRoomRequest)
        {
            await _unitOfWork.Rooms.AddEntityAsync(_mapper.Map<Room>(createRoomRequest));

            await _unitOfWork.CompleteAsync();
        }

        public async Task DisableRoomAsync(long id)
        {
            await _unitOfWork.Rooms.DisableAsync(id);

            await _unitOfWork.CompleteAsync();
        }

        public async Task<GetRoomResponse?> GetRoomByIdAsync(long id) => _mapper.Map<GetRoomResponse?>(await _unitOfWork.Rooms.GetEntityByIdAsync(id));

        public async Task<List<GetRoomResponse>> GetRoomListAsync() => _mapper.Map<List<GetRoomResponse>>(await _unitOfWork.Rooms.GetAllEntitiesAsync());

        public async Task UpdateRoomAsync(UpdateRoomRequest updateRoomRequest)
        {
            _unitOfWork.Rooms.UpdateEntity(_mapper.Map<Room>(updateRoomRequest));

            await _unitOfWork.CompleteAsync();
        }
    }
}
