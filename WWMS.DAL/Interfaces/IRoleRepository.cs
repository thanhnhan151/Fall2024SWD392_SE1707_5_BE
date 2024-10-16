using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
