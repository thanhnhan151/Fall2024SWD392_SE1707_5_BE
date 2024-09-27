using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IImportRequestRepository : IGenericRepository<ImportRequest>
    {
        Task UpdateStateAsync(long id);
        Task UpdateDeliveryStateAsync(long id);
    }
}
