namespace WWMS.DAL.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        // fix int => long because primary key of all table are long
        Task<TEntity?> GetEntityByIdAsync(long id);

        TEntity AddEntity(TEntity entity);

        void UpdateEntity(TEntity entity);

        Task<ICollection<TEntity>> GetAllEntitiesAsync();

        Task AddEntities(ICollection<TEntity> entities);
    }   
}
