using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
  public class WineRoomRepository : GenericRepository<WineRoom>, IWineRoomRepository
  {
    public WineRoomRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
    {
    }

    public async Task<ICollection<WineRoom>> GetAllActiveWineRoomAsync()
      => await _dbSet.Include(wr => wr.Room).Include(wr => wr.Wine)
        .ToListAsync();


    public async Task<WineRoom> GetEntityByIdWithWRInfoAsync(long id)
    {
      return await _dbSet
          .Include(wr => wr.Room)
          .Include(wr => wr.Wine)
          .FirstOrDefaultAsync(wr => wr.Id == id);
    }

  }
}