using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IBottleSizeRepository : IGenericRepository<BottleSize>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
