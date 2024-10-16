using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ITasteRepository : IGenericRepository<Taste>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
