﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WWMS.DAL.Persistences;

namespace WWMS.DAL.Infrastructures
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected WineWarehouseDbContext _context;
        protected DbSet<TEntity> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            WineWarehouseDbContext context,
            ILogger logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<TEntity>();
        }
        public virtual TEntity AddEntity(TEntity entity) => _dbSet.Add(entity).Entity;

        public virtual void UpdateEntity(TEntity entity) => _dbSet.Update(entity);

        public virtual async Task<TEntity?> GetEntityByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public virtual async Task<ICollection<TEntity>> GetAllEntitiesAsync() => await _dbSet.ToListAsync();

        public Task AddEntities(ICollection<TEntity> entities) => _dbSet.AddRangeAsync(entities);
    }
}