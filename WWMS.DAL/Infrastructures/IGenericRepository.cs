namespace WWMS.DAL.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetEntityByIdAsync(long id);

        Task AddEntityAsync(TEntity entity);

        void UpdateEntity(TEntity entity);

        Task<ICollection<TEntity>> GetAllEntitiesAsync();

        Task AddEntitiesAsync(ICollection<TEntity> entities);
    }   
}
