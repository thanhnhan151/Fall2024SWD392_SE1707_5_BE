using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<ICollection<Role>> GetAllEntitiesAsync()
            => await _dbSet.Where(r => r.Id != 1 && r.Id != 2).ToListAsync();

        public async Task<bool> CheckExistAsync(string request)
        {
            var user = await _dbSet.Where(u => u.RoleName == request.ToLower())
                                   .Select(u => new Role { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (user == null) return false;

            return true;
        }
    }
}
