using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            WineWarehouseDbContext context,
            ILogger logger
            ) : base(context, logger)
        {
        }

        public async Task DisableAsync(long id)
        {
            var checkExistUser = await _dbSet.FindAsync(id) ?? throw new Exception($"User with {id} does not exist");

            if (checkExistUser.AccountStatus == null) throw new Exception($"User {id}'s account status is null");

            if (checkExistUser.AccountStatus.Equals("Active"))
            {
                checkExistUser.AccountStatus = "Inactive";
            }
            else
            {
                checkExistUser.AccountStatus = "Active";
            }

            _dbSet.Update(checkExistUser);
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            try
            {
                var user = await _dbSet.Where(u => u.Username == username).FirstOrDefaultAsync();

                if (user == null) return null;

                if (BC.EnhancedVerify(password, user.PasswordHash)) return user;

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} LoginAsync method error", typeof(UserRepository));
                return new User();
            }
        }
    }
}
