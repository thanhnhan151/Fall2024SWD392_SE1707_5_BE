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

        public override async Task<Room?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(w => w.WineRooms).FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }

        public override async Task DisableAsync(long id)
        {
            var checkExistRoom = await _dbSet.FindAsync(id) ?? throw new Exception($"Room with id: {id} does not exist");

            if (checkExistRoom.Status == null) throw new Exception($"Room {id}'s status is null");

            if (checkExistRoom.Status.Equals("Active"))
            {
                checkExistRoom.Status = "Inactive";

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
