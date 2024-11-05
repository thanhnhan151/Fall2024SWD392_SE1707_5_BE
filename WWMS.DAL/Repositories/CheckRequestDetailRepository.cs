using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class CheckRequestDetailRepository : GenericRepository<CheckRequestDetail>, ICheckRequestDetailRepository
    {
        public CheckRequestDetailRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<ICollection<CheckRequestDetail>> GetAllByChecKerIdAsync(long checkerId)
        {
            return await _dbSet
                .Where(c => c.CheckerId == checkerId)
                .ToListAsync();
        }

        public async Task<ICollection<CheckRequestDetail>> GetAllCheckRequestDetailsByReporterNameAsync(string reporterName)
        => await _dbSet.Where(c => c.CheckerName.Equals(reporterName)).ToListAsync();

        public async Task<CheckRequestDetail> GetByIdWithCheckRequestAsync(long id)
        {
            return await _dbSet
                .Include(cr => cr.CheckRequest)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task<(int totalPositive, int totalNegative)> GetQuantityByMonthAndYearAsync(int month, int year)
        {
            int totalPositive = 0;
            int totalNegative = 0;

            var result = await _dbSet
                .Where(c => c.StartDate.HasValue
                            && c.StartDate.Value.Month == month
                            && c.StartDate.Value.Year == year
                            && c.Status == "ACTIVE")
                .ToListAsync();

            foreach (var newDetail in result)
            {

                int quantity = newDetail.ExpectedCurrQuantity - newDetail.ActualQuantity;

                if (quantity > 0)
                {
                    totalPositive += quantity;
                }
                else if (quantity < 0)
                {
                    totalNegative += Math.Abs(quantity);
                }
            }

            return (totalPositive, totalNegative);
        }

    }
}