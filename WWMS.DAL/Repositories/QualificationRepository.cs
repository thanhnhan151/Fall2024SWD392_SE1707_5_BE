using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class QualificationRepository : GenericRepository<Qualification>, IQualificationRepository
    {
        public QualificationRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var qualification = await _dbSet.Where(u => u.QualificationType == request.ToLower())
                                   .Select(u => new Qualification { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (qualification == null) return false;

            return true;
        }
    }
}
