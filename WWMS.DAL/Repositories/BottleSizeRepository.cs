using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class BottleSizeRepository : GenericRepository<BottleSize>, IBottleSizeRepository
    {
        public BottleSizeRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var bottleSize = await _dbSet.Where(u => u.BottleSizeType == request.ToLower())
                                   .Select(u => new BottleSize { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (bottleSize == null) return false;

            return true;
        }
    }
}
