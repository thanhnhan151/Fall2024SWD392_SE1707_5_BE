using WWMS.BAL.Models.CheckRequestReports;

namespace WWMS.BAL.Interfaces
{
    public interface IReportCheckRequestService
    {
        Task CreateCheckRequestReportAsync(CreateCheckRequestReportRequest request);
    }
}