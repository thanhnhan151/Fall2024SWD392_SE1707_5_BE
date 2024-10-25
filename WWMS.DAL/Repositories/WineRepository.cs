using Microsoft.AspNetCore.Http;
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
        public WineRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<ICollection<Wine>> GetAllEntitiesAsync()
            => await _dbSet.Select(w =>
            new Wine
            {
                Id = w.Id,
                WineName = w.WineName,
                AvailableStock = w.AvailableStock,
                Description = w.Description,
                ImageUrl = w.ImageUrl,
                Supplier = w.Supplier,
                MFD = w.MFD,
                ImportPrice = w.ImportPrice,
                ExportPrice = w.ExportPrice,
                Status = w.Status
            })
            .OrderByDescending(w => w.Id)
            .ToListAsync();

        public async Task<Wine?> GetByIdWithIncludeAsync(long id)
        {
            var result = await _dbSet
                .Include(c => c.WineCategory)
                .Include(c => c.Country)
                .Include(c => c.Taste)
                .Include(c => c.Class)
                .Include(c => c.Qualification)
                .Include(c => c.Cork)
                .Include(c => c.Brand)
                .Include(c => c.BottleSize)
                .Include(c => c.AlcoholByVolume)
                .Select(w =>
                        new Wine
                        {
                            Id = w.Id,
                            WineName = w.WineName,
                            AvailableStock = w.AvailableStock,
                            Description = w.Description,
                            ImageUrl = w.ImageUrl,
                            Supplier = w.Supplier,
                            MFD = w.MFD,
                            ImportPrice = w.ImportPrice,
                            ExportPrice = w.ExportPrice,
                            Country = w.Country,
                            WineCategory = w.WineCategory,
                            Taste = w.Taste,
                            Class = w.Class,
                            Qualification = w.Qualification,
                            Cork = w.Cork,
                            Brand = w.Brand,
                            BottleSize = w.BottleSize,
                            AlcoholByVolume = w.AlcoholByVolume
                        })
                .FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }

        public override async Task DisableAsync(long id)
        {
            var checkExistWine = await _dbSet.FindAsync(id) ?? throw new Exception($"Bottle of wine with {id} does not exist");

            if (checkExistWine.Status == null) throw new Exception($"Bottle of wine with {id}'s status is null");

            if (checkExistWine.Status.Equals("Active"))

            {
                checkExistWine.Status = "InActive";

                var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

                if (userName != null) checkExistWine.DeletedBy = userName.Value;

                checkExistWine.DeletedTime = DateTime.Now;
            }
            else
            {
                checkExistWine.Status = "Active";
            }

            _dbSet.Update(checkExistWine);
        }


        public async Task<Wine?> GetByIdNotTrack(long? id)
        {

            var localEntity = _dbSet.Local.FirstOrDefault(e => e.Id == id);


            if (localEntity == null)
            {
                localEntity = await _dbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
            }

            return localEntity;
        }
    }
}
