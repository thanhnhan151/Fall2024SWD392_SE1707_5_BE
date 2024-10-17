using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IIORequestDetailRepository : IGenericRepository<IORequestDetail>
    {
        Task CheckDoneAsync(long id);
    }
}
