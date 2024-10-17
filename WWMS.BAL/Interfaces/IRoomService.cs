using WWMS.BAL.Models.Rooms;

namespace WWMS.BAL.Interfaces
{
    public interface IRoomService
    {
        Task CreateRoomAsync(CreateRoomRequest createRoomRequest);

        Task<List<GetRoomResponse>> GetRoomListAsync();

        Task<GetRoomDetailResponse?> GetRoomByIdAsync(long id);

        Task UpdateRoomAsync(UpdateRoomRequest updateRoomRequest);

        Task DisableRoomAsync(long id);
    }
}
