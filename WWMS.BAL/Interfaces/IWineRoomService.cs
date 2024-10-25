using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WWMS.BAL.Models.WineRoom;

namespace WWMS.BAL.Interfaces
{
    public interface IWineRoomService
    {
        Task<List<GetActiveWineRoomNameResponse>> getActiveWineRoomNameResponseAsync();
    }
}