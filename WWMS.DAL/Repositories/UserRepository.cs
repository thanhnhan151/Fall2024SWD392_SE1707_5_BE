using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;
using WWMS.DAL.Interfaces;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(
            WineWarehouseDbContext context,
            ILogger logger,
            IHttpContextAccessor httpContextAccessor
            ) : base(context, logger)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<ICollection<User>> GetAllEntitiesAsync() => await _dbSet.Where(u => u.Id != GetLoggedUserId()).OrderByDescending(u => u.Id).ToListAsync();

        public async Task<bool> CheckExistUsernameAsync(string username)
        {
            var user = await _dbSet.Where(u => u.Username == username)
                                   .Select(u => new User { Id = u.Id })
                                   .FirstOrDefaultAsync();

            if (user == null) return false;

            return true;
        }

        public override async Task DisableAsync(long id)
        {
            var checkExistUser = await _dbSet.FindAsync(id) ?? throw new Exception($"User with {id} does not exist");

            if (checkExistUser.Status == null) throw new Exception($"User {id}'s account status is null");

            if (checkExistUser.Status.Equals("Active"))
            {
                checkExistUser.Status = "Inactive";

                var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Username", StringComparison.CurrentCultureIgnoreCase));

                if (userName != null) checkExistUser.DeletedBy = userName.Value;

                checkExistUser.DeletedTime = DateTime.Now;
            }
            else
            {
                checkExistUser.Status = "Active";
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

        private long GetLoggedUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase));

            if (userId == null) return 0;

            return long.Parse(userId.Value);
        }
    }
}
