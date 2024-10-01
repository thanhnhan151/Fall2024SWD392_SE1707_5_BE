using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class AdditionalImportRequestRepository : GenericRepository<AdditionalImportRequest>, IAdditionalImportRequestRepository
    {
        public AdditionalImportRequestRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {
        }
        public override async Task<ICollection<AdditionalImportRequest>> GetAllEntitiesAsync() => await _dbSet.Include(c => c.ImportRequest).Include(d => d.User).ToListAsync();

        public async Task UpdateStateAsync(long id)
        {
            var checkExistUser = await _dbSet.FindAsync(id) ?? throw new Exception($"Import Stick with {id} does not exist");

            if (checkExistUser.Status == null) throw new Exception($"Import Stick {id}'s status is null");

            if (checkExistUser.Status.Equals("In Progress"))
            {
                checkExistUser.Status = "Cancelled";
            }
            else
            {
                checkExistUser.Status = "In Progress";
            }

            _dbSet.Update(checkExistUser);
        }

        public async Task<ICollection<AdditionalImportRequest>> GetAdditionalByImportRequestCodeAsync(int req) =>  await _dbSet.Include(c => c.ImportRequestId == req).ToListAsync();
    }
}
