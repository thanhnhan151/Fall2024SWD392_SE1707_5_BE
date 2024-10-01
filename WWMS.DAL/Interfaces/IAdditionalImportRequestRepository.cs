using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IAdditionalImportRequestRepository : IGenericRepository<AdditionalImportRequest>
    {
        Task UpdateStateAsync(long id);

        Task<ICollection<AdditionalImportRequest>> GetAdditionalByImportRequestCodeAsync(int req);
    }
}
