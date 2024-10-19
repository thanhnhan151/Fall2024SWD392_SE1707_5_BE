using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<bool> CheckExistRoomName(string roomName);

        Task<Room?> GetByIdNotTrack(long? id);
    }
}
