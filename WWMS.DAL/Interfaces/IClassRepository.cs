using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IClassRepository : IGenericRepository<Class>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
