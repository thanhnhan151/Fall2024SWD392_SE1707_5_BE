using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class WineRepository : GenericRepository<Wine>, IWineRepository
    {
        public WineRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<ICollection<Wine>> GetAllEntitiesAsync() => await _dbSet.Include(c => c.WineCategory).ToListAsync();

        public override async Task<Wine?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(c => c.WineCategory).FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }

        public override async Task DisableAsync(long id)
        {
            var checkExistWine = await _dbSet.FindAsync(id) ?? throw new Exception($"Bottle of wine with {id} does not exist");

            if (checkExistWine.WineStatus == null) throw new Exception($"Bottle of wine with {id}'s status is null");

            if (checkExistWine.WineStatus.Equals("Active"))
            {
                checkExistWine.WineStatus = "Inactive";
            }
            else
            {
                checkExistWine.WineStatus = "Active";
            }

            _dbSet.Update(checkExistWine);
        }
    }
}
