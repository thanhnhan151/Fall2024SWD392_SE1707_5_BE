﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class TasteRepository : GenericRepository<Taste>, ITasteRepository
    {
        public TasteRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var taste = await _dbSet.Where(u => u.TasteType == request.ToLower())
                                   .Select(u => new Taste { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (taste == null) return false;

            return true;
        }
    }
}
