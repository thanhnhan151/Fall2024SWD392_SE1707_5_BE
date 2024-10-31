using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> LoginAsync(string username, string password);

        Task<User?> GetUserInfoAsync(long id);

        Task<bool> CheckExistUsernameAsync(string username);

        Task<bool> CheckExistEmailAsync(string email);

        Task<User?> GetByUsernameAsync(string username);

        Task<ICollection<User>> GetAllStaffAsync();
    }
}
