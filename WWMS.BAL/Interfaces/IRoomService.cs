using System.Threading.Tasks;
using WWMS.BAL.Models.Rooms;
using WWMS.BAL.Models.WineRoom;

namespace WWMS.BAL.Interfaces
{
    public interface IRoomService
    {
        Task CreateRoomAsync(CreateRoomRequest createRoomRequest);

        Task<List<GetRoomResponse>> GetRoomListAsync();

        Task<GetRoomDetailResponse?> GetRoomByIdAsync(long id);

        Task<GetRoom?> GetWineRoomByIdAsync(long id);
        Task UpdateRoomAsync(long id, UpdateRoomRequest updateRoomRequest);

        Task DisableRoomAsync(long id);
    }
}
