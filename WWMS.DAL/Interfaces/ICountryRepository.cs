using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<bool> CheckExistAsync(string request);
    }
}
