using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class ReportRepository : GenericRepository<IORequestDetail>, IReportRepository
    {
        public ReportRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        //public async Task DisableReportsAsync(long ioRequestId, long detailId)
        //{
        //    // Tìm IORequest cha
        //    var parentRequest = await _dbSet.FindAsync(ioRequestId);
        //    if (parentRequest == null)
        //    {
        //        throw new Exception("IORequest not found.");
        //    }

        //    // Kiểm tra trạng thái của IORequest
        //    if (parentRequest.IORequest.Status != "Pending")
        //    {
        //        throw new Exception("IORequest status must be 'Pending' to proceed.");
        //    }

        //    // Tìm chi tiết để xóa
        //    var detailToRemove = await _context.IORequestDetails.FindAsync(detailId);
        //    if (detailToRemove == null)
        //    {
        //        throw new Exception("Detail not found.");
        //    }

        //    // Reset các thuộc tính liên quan đến Report
        //    detailToRemove.ReportCode = null;
        //    detailToRemove.ReportDescription = null;
        //    detailToRemove.ReporterAssigned = null;
        //    detailToRemove.DiscrepanciesFound = null;
        //    detailToRemove.ReportFile = null;

        //    // Xóa detailToRemove
        //    _context.IORequestDetails.Update(detailToRemove);
        //    await _context.SaveChangesAsync();
        //}
    }
}
