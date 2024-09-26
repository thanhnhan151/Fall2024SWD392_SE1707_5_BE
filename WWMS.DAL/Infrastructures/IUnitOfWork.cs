using WWMS.DAL.Interfaces;

namespace WWMS.DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IImportRequestRepository Imports { get; }

        Task CompleteAsync();
    }
}
