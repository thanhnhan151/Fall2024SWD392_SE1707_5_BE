using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.IORequestDetails;
using WWMS.BAL.Models.IORequests;
using WWMS.BAL.Models.ReportIORequest;

namespace WWMS.BAL.Interfaces
{
    public interface IReportIORequestService
    {
 //        Task CreateReportIORequestAsync(CreateIORequest createIORequest);

        Task<List<GetReportIORequest>> GetReportIORequestListAsync();

        Task<GetReportIORequest?> GetReportIORequestByIdAsync(long id);

        Task UpdateReportIORequestAsync(UpdateReportIORequest updateReportIO,string file);


        Task DisableReportIORequestsAsync(long id);
    }
}
