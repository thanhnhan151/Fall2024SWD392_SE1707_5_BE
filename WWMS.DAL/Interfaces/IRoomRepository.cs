﻿using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<Room?> GetByIdWithIncludeAsync(long id);

        Task<bool> CheckExistRoomName(string roomName);

        Task<ICollection<Room>> GetAllAvailableRoomsAsync();

        Task<ICollection<Room>> GetAllAvailableRoomsForExportAsync();

        Task<Room?> GetByIdWithIncludeForExportAsync(long id);

        Task<Room?> GetByIdNotTrack(long? id);
    }
}
