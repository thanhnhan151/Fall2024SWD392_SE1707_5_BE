using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task DisableAsync(long id);
    }
}
