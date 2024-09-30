using WWMS.BAL.Models.ImportRequests;

namespace WWMS.BAL.Interfaces
{
    public interface IImportRequestService
    {
        Task<List<GetImportRequestRespone>> GetImportRequestAsync();

        Task<GetImportRequestRespone> GetImportRequestByIdAsync(long Import_id);

        Task CreateImportRequestAnync(CreateImportRequest Import);

        Task UpdateImportRequestAsync(UpdateImportRequest Import);

        Task DisableImportRequestAsync(long id);

        Task DisableImportDeliveryRequestAsync(long id);
    }
}
