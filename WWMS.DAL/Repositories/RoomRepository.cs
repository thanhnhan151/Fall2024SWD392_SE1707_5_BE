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
        public RoomRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<ICollection<Room>> GetAllEntitiesAsync() => await _dbSet.Include(w => w.WineRooms).ToListAsync();

        public override async Task<Room?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(w => w.WineRooms).FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }
    }
}
