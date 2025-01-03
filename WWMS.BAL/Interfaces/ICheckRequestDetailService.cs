using WWMS.BAL.Models.CheckRequests;
using WWMS.BAL.Models.CheckRequests.Report;

namespace WWMS.BAL.Interfaces
{
    public interface ICheckRequestDetailService
    {
        //get all the check request details
        Task<List<GetCheckRequestDetailListItemResponse>> GetAllAsync();
        //get all by assignee to write the report (TASK LIST)
        Task<List<GetCheckRequestDetailListItemResponse>> GetAllByReporterNameAsync(string reporterName);
        //update the detail
        Task UpdateCheckRequestDetailAsync(UpdateCheckRequestDetailRequest updateCheckRequestDetailRequest);
        //create detail
        Task CreateCheckRequestDetailAsync(CreateAdditionalCheckRequestDetailRequest createCheckRequestDetailRequest);
        //delete the detail
        Task DisableCheckRequestDetailAsync(long id);
        Task<GetCheckRequestDetailViewDetailResponse> GetByIdAsync(long id);
    }
}