using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ICorkRepository : IGenericRepository<Cork>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
