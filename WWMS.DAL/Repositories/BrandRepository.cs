﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public async Task<bool> CheckExistAsync(string request)
        {
            var brand = await _dbSet.Where(u => u.BrandName == request.ToLower())
                                   .Select(u => new Brand { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (brand == null) return false;

            return true;
        }
    }
}
