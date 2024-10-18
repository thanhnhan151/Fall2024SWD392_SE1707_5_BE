using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IWineCategoryRepository : IGenericRepository<WineCategory>
    {
        Task<WineCategory?> GetAllWinesByWineCategoryIdAsync(long id);

    }
}
