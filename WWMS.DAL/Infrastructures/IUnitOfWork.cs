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

        IRoleRepository Roles { get; }

        ICountryRepository Countries { get; }
        
        ITasteRepository Tastes { get; }

        IClassRepository Classes { get; }

        IQualificationRepository Qualifications { get; }

        ICorkRepository Corks { get; }

        IBrandRepository Brands { get; }

        IBottleSizeRepository BottleSizes { get; }

        IAlcoholByVolumeRepository AlcoholByVolumes { get; }

        Task CompleteAsync();
    }
}
