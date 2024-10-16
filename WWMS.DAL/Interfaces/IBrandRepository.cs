using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
