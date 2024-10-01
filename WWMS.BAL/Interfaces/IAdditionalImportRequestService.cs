using WWMS.BAL.Models.AdditionalImportRequests;

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
