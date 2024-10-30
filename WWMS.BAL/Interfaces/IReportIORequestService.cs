using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.ReportIORequest;

namespace WWMS.BAL.Interfaces
{
    public interface IReportIORequestService
    {

        Task<List<GetReportIORequest>> GetReportIORequestListAsync();

        Task<GetReportIORequest?> GetReportIORequestByIdAsync(long id);

        Task UpdateReportIORequestDetailsByIdAsync(CreateReport updateIORequest, long id);

        Task<List<GetReportIORequest>> GetReportByIORequestidAsync(long id);
        Task DisableReportIORequestsAsync(long id, long idDetails);
    }
}
