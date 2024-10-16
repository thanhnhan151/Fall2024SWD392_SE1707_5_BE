using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IAlcoholByVolumeRepository : IGenericRepository<AlcoholByVolume>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
