using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IIORequestRepository : IGenericRepository<IORequest>
    {
        Task<IORequest?> GetAllIORequestDetailsByIORequestAsync(long id);
    }
}
