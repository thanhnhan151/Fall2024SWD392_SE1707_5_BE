using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class ImportRequestRepository : GenericRepository<ImportRequest>, IImportRequestRepository
    {
        public ImportRequestRepository(WineWarehouseDbContext context, ILogger logger) : base(context, logger)
        {

        }

        // In Progress , Completed ,Cancelled
        public override async Task DisableAsync(long id)
        {
            var checkExistUser = await _dbSet.FindAsync(id) ?? throw new Exception($"Import Stick with {id} does not exist");

            if (checkExistUser.DeliveryStatus == null) throw new Exception($"Import Stick {id}'s status is null");

            if (checkExistUser.DeliveryStatus.Equals("In Progress"))
            {
                checkExistUser.DeliveryStatus = "Cancelled";
            }
            else
            {
                checkExistUser.DeliveryStatus = "In Progress";
            }

            _dbSet.Update(checkExistUser);
        }
    }
}
