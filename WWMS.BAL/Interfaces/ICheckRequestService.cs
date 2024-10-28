using WWMS.BAL.Models.CheckRequests;

namespace WWMS.BAL.Interfaces
{
    public interface ICheckRequestService
    {
        Task CreateRequestAsync(CreateCheckRequestRequest createCheckRequestRequest);

        Task<List<GetCheckRequestResponse>> GetCheckRequestListAsync();

        Task<GetCheckRequestWithDetailsResponse?> GetCheckRequestByIdAsync(long id);

        Task UpdateCheckRequestAsync(UpdateCheckRequestRequest updateCheckRequestRequest);

        Task DisableAsync(long id);
    }
}