using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class WineCategoryRepository : GenericRepository<WineCategory>, IWineCategoryRepository
    {
        public WineCategoryRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<WineCategory?> GetAllWinesByWineCategoryIdAsync(long id)
            => await _dbSet.Include(w => w.Wines)
                           .FirstOrDefaultAsync(c => c.Id == id);
    }
}
