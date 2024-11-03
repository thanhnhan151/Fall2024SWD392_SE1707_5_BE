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

        public override async Task<ICollection<IORequest>> GetAllEntitiesAsync()
            => await _dbSet
                        .Include(c => c.IORequestDetails)
                        .OrderByDescending(c => c.Id)
                        .ToListAsync();

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
                .OrderByDescending(c => c.Id) 
                .ToListAsync();

            return result;
        }

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
                throw new Exception("IORequest status must be 'Pending' to Delete.");
            }

            _dbSet.Update(checkExist);
            await _context.SaveChangesAsync();
        }

        public async Task DisableDetailsAsync(long id, long detailsId)
        {

            var parentRequest = await _dbSet.FindAsync(id);
            if (parentRequest == null)
            {
                throw new Exception("IORequest not found.");
            }
            if (parentRequest.Status != "Pending")
            {
                throw new Exception("IORequest status must be 'Pending' to proceed.");
            }

            var detailToRemove = await _context.IORequestDetails.FindAsync(detailsId);
            if (detailToRemove == null)
            {
                throw new Exception("Detail not found.");
            }

            _context.IORequestDetails.Remove(detailToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetImportRequestPriceForPaymentAsync(long id)
        {
            decimal sum = 0;

            var result = await _dbSet.Where(i => i.Id == id)
                           .Select(i => new IORequest
                           {
                               IORequestDetails = i.IORequestDetails.Select(i => new IORequestDetail
                               {
                                   Quantity = i.Quantity,
                                   Wine = new Wine
                                   {
                                       ImportPrice = i.Wine.ImportPrice
                                   }
                               }).ToList()
                           })
                           .FirstOrDefaultAsync();

            if (result == null) return 0;

            foreach (var item in result.IORequestDetails)
            {
                sum += item.Quantity * item.Wine.ImportPrice;
            }

            return sum;
        }
    }
}
