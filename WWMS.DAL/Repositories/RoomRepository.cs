using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<ICollection<Room>> GetAllEntitiesAsync()
            => await _dbSet.OrderByDescending(r => r.Id)
                     .Select(r => new Room
                     {
                         Id = r.Id,
                         RoomName = r.RoomName,
                         LocationAddress = r.LocationAddress,
                         Capacity = r.Capacity,
                         CurrentOccupancy = r.CurrentOccupancy,
                         ManagerName = r.ManagerName ?? "N/A",
                         Status = r.Status
                     })
                     .ToListAsync();

        public async Task<ICollection<Room>> GetAllAvailableRoomsAsync()
            => await _dbSet.Where(r => r.Status.Equals("Active")
                                    && r.Capacity - r.CurrentOccupancy >= 20)
                           .Select(r => new Room
                           {
                               Id = r.Id,
                               RoomName = r.RoomName,
                               Capacity = r.Capacity,
                               CurrentOccupancy = r.CurrentOccupancy
                           })
                           .ToListAsync();

        public async Task<ICollection<Room>> GetAllAvailableRoomsForExportAsync()
        => await _dbSet.Where(r => r.Status.Equals("Active")
                                    && r.WineRooms.Count() > 0)
                           .Select(r => new Room
                           {
                               Id = r.Id,
                               RoomName = r.RoomName,
                               WineRooms = r.WineRooms.Select(w => new WineRoom
                               {
                                   Id = w.Id
                               }).ToList()
                           })
                           .ToListAsync();

        public async Task<Room?> GetByIdWithIncludeForExport(long id)
        {
            var result = await _dbSet
                .Where(c => c.Id == id)
                .Select(r => new Room
                {
                    Id = r.Id,
                    WineRooms = r.WineRooms
                                 .Where(r => r.CurrentQuantity > 0)
                                 .Select(w => new WineRoom
                                 {
                                     WineId = w.WineId,
                                     CurrentQuantity = w.CurrentQuantity,
                                     Wine = new Wine
                                     {
                                         WineName = w.Wine.WineName
                                     }
                                 }).ToList()
                })
                .FirstOrDefaultAsync();

            if (result != null) return result;

            return null;
        }

        public async Task<Room?> GetByIdWithIncludeAsync(long id)
        {
            var result = await _dbSet
                .Where(c => c.Id == id)
                .Select(r => new Room
                {
                    Id = r.Id,
                    RoomName = r.RoomName,
                    LocationAddress = r.LocationAddress,
                    Capacity = r.Capacity,
                    CurrentOccupancy = r.CurrentOccupancy,
                    ManagerName = r.ManagerName ?? "N/A",
                    Status = r.Status,
                    WineRooms = r.WineRooms.Select(w => new WineRoom
                    {
                        Id = w.Id,
                        WineId = w.WineId,
                        InitialQuantity = w.InitialQuantity,
                        Import = w.Import,
                        Export = w.Export,
                        CurrentQuantity = w.CurrentQuantity,
                        Wine = new Wine
                        {
                            WineName = w.Wine.WineName
                        }
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (result != null) return result;

            return null;
        }

        public override async Task DisableAsync(long id)
        {
            var checkExistRoom = await _dbSet.FindAsync(id) ?? throw new Exception($"Room with id: {id} does not exist");

            if (checkExistRoom.Status == null) throw new Exception($"Room {id}'s status is null");

            if (checkExistRoom.Status.Equals("Active"))
            {
                checkExistRoom.Status = "InActive";

                var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

                if (userName != null) checkExistRoom.DeletedBy = userName.Value;

                checkExistRoom.DeletedTime = DateTime.Now;
            }
            else
            {
                checkExistRoom.Status = "Active";
            }

            _dbSet.Update(checkExistRoom);
        }

        public async Task<Room?> GetByIdNotTrack(long? id)
        {

            var localEntity = _dbSet.Local.FirstOrDefault(e => e.Id == id);


            if (localEntity == null)
            {
                localEntity = await _dbSet
                    .AsNoTracking()
                    .Include(w => w.WineRooms)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }

            return localEntity;
        }

        public async Task<bool> CheckExistRoomName(string roomName)
        {
            var room = await _dbSet.Where(r => r.RoomName == roomName)
                                   .Select(r => new Room { Id = r.Id })
                                   .FirstOrDefaultAsync();

            if (room == null) return false;

            return true;
        }
    }
}
