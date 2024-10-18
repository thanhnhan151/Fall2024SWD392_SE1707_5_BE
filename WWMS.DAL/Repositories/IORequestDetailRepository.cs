
﻿using Microsoft.AspNetCore.Http;

﻿using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class IORequestDetailRepository : GenericRepository<IORequestDetail>, IIORequestDetailRepository
    {
        public IORequestDetailRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {

        }

        public override async Task<ICollection<IORequestDetail>> GetAllEntitiesAsync() => await _dbSet.Include(w => w.IORequest).ToListAsync();

        // chua xai dc
        public async Task<IORequestDetail> CheckDoneAsync(long id)
        {
            var checkExist = await _dbSet.FindAsync(id) ?? throw new Exception($"Report of IOrequestdetails with {id} does not exist");

            if (checkExist == null) throw new Exception($"Report of IOrequestdetails with {id} is null");

            // Nếu trạng thái là Cancel hoặc Done thì không thay đổi
            if (checkExist.Status.Equals("Cancel", StringComparison.OrdinalIgnoreCase) ||
                checkExist.Status.Equals("Done", StringComparison.OrdinalIgnoreCase))
            {
                return checkExist;
            }

            // Nếu trạng thái là InProcess thì đổi thành Done
            if (checkExist.Status.Equals("InProcess", StringComparison.OrdinalIgnoreCase))
            {
                checkExist.Status = "Done";
                _dbSet.Update(checkExist); // Chỉ cập nhật nếu có sự thay đổi trạng thái
            }

            return checkExist; // Trả về đối tượng checkExist đã cập nhật hoặc giữ nguyên
        }

        public override async Task DisableAsync(long id)
        {
            var checkExist= await _dbSet.FindAsync(id) ?? throw new Exception($"Report of IOrequestdetails with {id} does not exist");

            if (checkExist == null) throw new Exception($"Report of IOrequestdetails with {id} is null");

            checkExist.ReportCode = "";
            checkExist.ReportDescription = "";
            checkExist.ReporterAssigned = "";
            checkExist.ActualQuantity = 0;
            checkExist.DiscrepanciesFound = 0;
            checkExist.ReportFile = "";

            _dbSet.Update(checkExist);
        }
    }
}
