using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class SuplierRepository : GenericRepository<Suplier>, ISuplierRepository
    {
        public SuplierRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var suplier = await _dbSet.Where(u => u.SuplierName == request.ToLower())
                                   .Select(u => new Suplier { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (suplier == null) return false;

            return true;
        }
    }
}
