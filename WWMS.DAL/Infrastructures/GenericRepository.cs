using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected WineWarehouseDbContext _context;
        protected DbSet<TEntity> _dbSet;
        protected readonly ILogger _logger;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public GenericRepository(
            WineWarehouseDbContext context,
            ILogger logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual async Task AddEntityAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public virtual void UpdateEntity(TEntity entity) => _dbSet.Update(entity);

        public virtual async Task<TEntity?> GetEntityByIdAsync(long id)
        {
            var result = await _dbSet.FindAsync(id);

            if (result != null) return result;

            return null;
        }

        public virtual async Task<ICollection<TEntity>> GetAllEntitiesAsync() => await _dbSet.ToListAsync();

        public virtual async Task AddEntitiesAsync(ICollection<TEntity> entities) => await _dbSet.AddRangeAsync(entities);

        public virtual Task DisableAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
