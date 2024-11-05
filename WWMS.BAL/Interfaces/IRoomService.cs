using WWMS.BAL.Models.Rooms;

namespace WWMS.BAL.Interfaces
{
    public interface IRoomService
    {
        Task CreateRoomAsync(CreateRoomRequest createRoomRequest);

        Task<List<GetRoomResponse>> GetRoomListAsync();

        Task<List<GetAvailableRoomResponse>> GetAvailableRoomListAsync();

        Task<GetRoomDetailResponse?> GetRoomByIdAsync(long id);

        Task<List<GetExportRoomResponse>> GetExportRoomListAsync();

        Task<GetExportRoomDetailResponse?> GetExportRoomByIdAsync(long id);

        Task UpdateRoomAsync(long id, UpdateRoomRequest updateRoomRequest);

        Task DisableRoomAsync(long id);
    }
}
