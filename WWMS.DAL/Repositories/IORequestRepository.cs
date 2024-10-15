using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class IORequestRepository : GenericRepository<IORequest>, IIORequestRepository
    {
        public IORequestRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<ICollection<IORequest>> GetAllEntitiesAsync() => await _dbSet.Include(w => w.IORequestDetails).ToListAsync();

        public async Task<IORequest?> GetAllIORequestDetailsByIORequestAsync(long id)
    => await _dbSet.Include(w => w.IORequestDetails)
                   .FirstOrDefaultAsync(c => c.Id == id);

        public override async Task<IORequest?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(w => w.IORequestDetails).FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }

        public override async Task DisableAsync(long id)
        {
           
            var checkExistWine = await _dbSet
                .Include(r => r.IORequestDetails) 
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new Exception($"Import/Export {id} does not exist");


            if (checkExistWine.Status == null)
                throw new Exception($"Import/Export with {id}'s status is null");


            if (checkExistWine.Status.Equals("Active", StringComparison.OrdinalIgnoreCase))
            {
                checkExistWine.Status = "Inactive";


                foreach (var detail in checkExistWine.IORequestDetails)
                {
                    detail.Status = "Cancel";
                }
            }
            else
            {

                checkExistWine.Status = "Active";
            }

      
            _dbSet.Update(checkExistWine);

            await _context.SaveChangesAsync();
        }
    }
}
