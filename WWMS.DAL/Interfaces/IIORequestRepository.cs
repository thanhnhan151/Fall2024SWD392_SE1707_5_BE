using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IIORequestRepository : IGenericRepository<IORequest>
    {
        Task<IORequest?> GetAllIORequestDetailsByIORequestAsync(long id);
        Task<List<IORequest>> GetEntitiesByIOStyleAsync(string ioType);

        Task<List<IORequest>> GetEntitiesByIOStyleMonthAndYearAsync(string ioType, int month, int year);
    }
}
