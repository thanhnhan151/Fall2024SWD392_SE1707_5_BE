using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWMS.BAL.Models.CheckRequests;

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
        Task CreateCheckRequestDetailAsync(CreateCheckRequestDetailRequest createCheckRequestDetailRequest);
        //delete the detail
        Task DisableCheckRequestDetailAsync(long id);


        #region report for the check request detail
        //create report for the check request detail

        //delete report for the check request detail

        //update report for the check request detail
        #endregion
    }
}