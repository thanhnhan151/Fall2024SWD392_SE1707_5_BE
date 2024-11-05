using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class CheckRequestRepository : GenericRepository<CheckRequest>, ICheckRequestRepository
    {
        public CheckRequestRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }
        public override async Task<ICollection<CheckRequest>> GetAllEntitiesAsync()
        {
            return await _dbSet.Include(cr => cr.CheckRequestDetails).ToListAsync();
        }
        public override async Task<CheckRequest> GetEntityByIdAsync(long id)
        {
            return await _dbSet
                .Include(cr => cr.CheckRequestDetails)
                .FirstOrDefaultAsync(cr => cr.Id == id);
        }

        //QUERY ACTIVE ONLY
        public async Task<ICollection<CheckRequest>> GetAllEntitiesActiveAsync()
        {
            return await _dbSet.Where(cr => string.Equals(cr.Status, "ACTIVE")).ToListAsync();
        }
    }
}