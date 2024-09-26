using WWMS.DAL.Interfaces;

namespace WWMS.DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }


        IWineRepository Wines { get; }

        IImportRequestRepository Imports { get; }


        Task CompleteAsync();
    }
}
