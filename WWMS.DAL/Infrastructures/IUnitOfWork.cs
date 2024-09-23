namespace WWMS.DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
