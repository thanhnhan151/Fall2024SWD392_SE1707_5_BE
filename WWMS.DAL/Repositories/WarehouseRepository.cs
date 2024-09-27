using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<ICollection<Warehouse>> GetAllEntitiesAsync()
            => await _dbSet.Include(w => w.WineWarehouses)
                                   .ThenInclude(w => w.Wine)
                           .ToListAsync();

        public override async Task<Warehouse?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(w => w.WineWarehouses)
                                             .ThenInclude(w => w.Wine)
                                     .FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }
    }
}
