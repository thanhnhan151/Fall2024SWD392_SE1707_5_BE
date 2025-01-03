using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface IWineRoomRepository : IGenericRepository<WineRoom>
    {
        Task<ICollection<WineRoom>> GetAllActiveWineRoomAsync();
        Task<WineRoom> GetEntityByIdWithWRInfoAsync(long id);
    }
}