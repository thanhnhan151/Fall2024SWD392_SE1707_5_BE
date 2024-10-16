using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class TasteRepository : GenericRepository<Taste>, ITasteRepository
    {
        public TasteRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var user = await _dbSet.Where(u => u.TasteType == request)
                                   .Select(u => new AlcoholByVolume { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (user == null) return false;

            return true;
        }
    }
}
