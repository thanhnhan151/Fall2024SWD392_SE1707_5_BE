using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.AdditionalImportRequests;
using WWMS.BAL.Models.ImportRequests;

namespace WWMS.BAL.Interfaces
{
    public interface IAdditionalImportRequestService
    {
        Task<List<GetAdditionalImportRequest>> GetAdditionalImportRequestAsync();

        Task<GetAdditionalImportRequest> GetAdditionalImportRequestIdAsync(long Import_id);

        Task CreateAdditionalImportRequestAnync(CreateAdditionalImportRequest Import);

        Task UpdateAdditionalImportRequestAsync(UpdateAdditionalImportRequest Import);

        Task DisableAdditionalImportRequestAsync(long id);

        //       Task DisableImportDeliveryRequestAsync(long id);
    }
}
