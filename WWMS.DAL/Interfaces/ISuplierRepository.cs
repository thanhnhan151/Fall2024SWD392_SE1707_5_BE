using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ISuplierRepository : IGenericRepository<Suplier>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
