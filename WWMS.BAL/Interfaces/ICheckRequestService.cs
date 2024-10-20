using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWMS.BAL.Models.CheckRequests;

namespace WWMS.BAL.Interfaces
{
    public interface ICheckRequestService
    {
        Task CreateRequestAsync(CreateCheckRequestRequest createCheckRequestRequest);

        Task<List<GetCheckRequestResponse>> GetCheckRequestListAsync();

        Task<GetCheckRequestWithDetailsResponse?> GetCheckRequestByIdAsync(long id);

        Task UpdateCheckRequestAsync (UpdateCheckRequestRequest updateCheckRequestRequest);

        Task DisableAsync (long id, DisableCheckRequestRequest request);
    }
}