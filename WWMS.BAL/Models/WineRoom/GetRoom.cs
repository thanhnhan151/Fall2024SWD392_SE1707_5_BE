using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.Rooms;

namespace WWMS.BAL.Models.WineRoom
{
    public class GetRoom
    {
        public long Id { get; set; }
        public string RoomName { get; set; } = null!;
        public string? LocationAddress { get; set; }
        public int? Capacity { get; set; }
        public int? CurrentOccupancy { get; set; }
        public string? ManagerName { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<GetWineRoom> WineRooms { get; set; } = [];
    }
}
