using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> LoginAsync(string username, string password);

        Task<bool> CheckExistUsernameAsync(string username);

        Task<User?> GetByUsernameAsync(string username);
    }
}
