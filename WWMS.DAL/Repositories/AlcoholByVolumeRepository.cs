using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class AlcoholByVolumeRepository : GenericRepository<AlcoholByVolume>, IAlcoholByVolumeRepository
    {
        public AlcoholByVolumeRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var alcoholByVolume = await _dbSet.Where(u => u.AlcoholByVolumeType == request.ToLower())
                                   .Select(u => new AlcoholByVolume { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (alcoholByVolume == null) return false;

            return true;
        }
    }
}
