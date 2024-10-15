using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class IORequestDetailRepository : GenericRepository<IORequestDetail>, IIORequestDetailRepository
    {
        public IORequestDetailRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<ICollection<IORequestDetail>> GetAllEntitiesAsync() => await _dbSet.Include(w => w.IORequest).ToListAsync();
    }
}
