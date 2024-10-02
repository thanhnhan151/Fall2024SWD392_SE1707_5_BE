using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IImportRequestRepository : IGenericRepository<ImportRequest>
    {
        Task UpdateStateAsync(long id);
        Task<ImportRequest> UpdateStatusSuccessAsync(long id);
        Task UpdateDeliveryStateAsync(long id);
        Task<ImportRequest?> GetEntityByIdAsync(long id);

    }
}
