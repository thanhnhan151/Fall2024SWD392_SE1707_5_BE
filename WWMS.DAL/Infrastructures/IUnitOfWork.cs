using WWMS.DAL.Interfaces;

namespace WWMS.DAL.Infrastructures
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IWineRepository Wines { get; }

        IWineCategoryRepository WineCategories { get; }

        IRoomRepository Rooms { get; }

        IIORequestRepository IIORequests { get; }

        IIORequestDetailRepository IIORequestsDetail { get; }

        Task CompleteAsync();
    }
}
