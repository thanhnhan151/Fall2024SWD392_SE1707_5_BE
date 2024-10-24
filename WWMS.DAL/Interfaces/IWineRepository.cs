using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IWineRepository : IGenericRepository<Wine>
    {
        Task<Wine?> GetByIdWithIncludeAsync(long id);

        Task<Wine?> GetByIdNotTrack(long? id);
    }
}
