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
        public UserRepository(WineWarehouseDbContext context, ILogger logger, IHttpContextAccessor httpContextAccessor) : base(context, logger, httpContextAccessor)
        {
        }

        public override async Task<ICollection<User>> GetAllEntitiesAsync()
            => await _dbSet.Where(u => u.Id != GetLoggedUserId())
                           .Include(u => u.Role)
                           .OrderByDescending(u => u.Id)
                           .ToListAsync();

        public override async Task<User?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.Include(c => c.Role).FirstOrDefaultAsync(c => c.Id == id);

            if (result != null) return result;

            return null;
        }

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
            long Id = 0;

            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("Id", StringComparison.CurrentCultureIgnoreCase));

            if (userId != null) Id = long.Parse(userId.Value);

            if (Id == id) throw new Exception($"User with Id: {id} is currently logging in");

            var checkExistUser = await _dbSet.FindAsync(id) ?? throw new Exception($"User with Id: {id} does not exist");

            if (checkExistUser.Status == null) throw new Exception($"User {id}'s status is null");

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
                var user = await _dbSet.Include(u => u.Role)
                                       .Where(u => u.Username == username)
                                       .FirstOrDefaultAsync();

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

        public async Task<User?> GetByUsernameAsync(string username) => await _dbSet.Where(u => u.Username.Equals(username)).FirstOrDefaultAsync();
    }
}
