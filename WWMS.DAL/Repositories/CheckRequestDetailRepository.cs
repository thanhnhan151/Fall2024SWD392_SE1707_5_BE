using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ICollection<CheckRequestDetail>> GetAllCheckRequestDetailsByReporterNameAsync(string reporterName)
        => await _dbSet.Where(c => c.ReporterAssigned.Equals(reporterName)).ToListAsync();
    }
}