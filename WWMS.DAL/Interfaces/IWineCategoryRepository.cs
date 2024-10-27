using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IWineCategoryRepository : IGenericRepository<WineCategory>
    {
        Task<bool> CheckExistAsync(string request);
        Task<WineCategory?> GetAllWinesByWineCategoryIdAsync(long id);
    }
}
