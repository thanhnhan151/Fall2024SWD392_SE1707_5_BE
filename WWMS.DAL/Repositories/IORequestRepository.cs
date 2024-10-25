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

        public override async Task<ICollection<IORequest>> GetAllEntitiesAsync() => await _dbSet.Include(c => c.IORequestDetails).ToListAsync();



        public async Task<IORequest?> GetAllIORequestDetailsByIORequestAsync(long id)
    => await _dbSet.Include(w => w.IORequestDetails)
                   .FirstOrDefaultAsync(c => c.Id == id);

        public override async Task<IORequest?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(w => w.IORequestDetails).FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }

        public async Task<List<IORequest>> GetEntitiesByIOStyleAsync(string ioType)
        {
            var result = await _dbSet
                .Where(c => c.IOType == ioType) 
                .ToListAsync(); 

            return result;
        }
        //
        public async Task<List<IORequest>> GetEntitiesByIOStyleMonthAndYearAsync(string ioType, int month, int year)
        {
            var result = await _dbSet
                .Where(c => c.IOType == ioType
                            && c.StartDate.HasValue
                            && c.StartDate.Value.Month == month
                            && c.StartDate.Value.Year == year)
                .ToListAsync();

            return result;
        }

        public override async Task DisableAsync(long id)
        {
           
            var checkExist = await _dbSet
                .Include(r => r.IORequestDetails) 
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new Exception($"Import/Export {id} does not exist");


            if (checkExist.Status == null)
                throw new Exception($"Import/Export with {id}'s status is null");


            if (checkExist.Status.Equals("Pending", StringComparison.OrdinalIgnoreCase))
            {
                checkExist.Status = "Cancel";

            }
            else
            {
                throw new Exception($"Import/Export {id} does not exist");
            }


      
            _dbSet.Update(checkExist);

            await _context.SaveChangesAsync();
        }
    }
}
