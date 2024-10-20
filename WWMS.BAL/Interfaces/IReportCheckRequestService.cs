using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWMS.BAL.Models.CheckRequestReports;

namespace WWMS.BAL.Interfaces
{
    public interface IReportCheckRequestService
    {
        Task CreateCheckRequestReportAsync(CreateCheckRequestReportRequest request);
        Task<GetCheckRequestReportResponse> GetReportByCheckRequestDetailIdAsync(int id);
        Task UpdateCheckRequestReportAsync(UpdateCheckRequestReportRequest request);
    }
}