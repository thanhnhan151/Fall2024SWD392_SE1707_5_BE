using Microsoft.AspNetCore.Http;
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
        public WineCategoryRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var category = await _dbSet.Where(u => u.CategoryName == request.ToLower())
                                   .Select(u => new WineCategory { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (category == null) return false;

            return true;
        }

        public async Task<WineCategory?> GetAllWinesByWineCategoryIdAsync(long id)
            => await _dbSet.Where(c => c.Id == id)
                           .Select(c => new WineCategory
                           {
                               Id = c.Id,
                               CategoryName = c.CategoryName,
                               Wines = c.Wines
                                     .Select(w => new Wine
                                     {
                                         Id = w.Id,
                                         WineName = w.WineName,
                                         Description = w.Description,
                                         MFD = w.MFD,
                                         ImageUrl = w.ImageUrl,
                                         ImportPrice = w.ImportPrice,
                                         ExportPrice = w.ExportPrice,
                                         Status = w.Status
                                     }).ToList()
                           })
                           .FirstOrDefaultAsync();
    }
}
