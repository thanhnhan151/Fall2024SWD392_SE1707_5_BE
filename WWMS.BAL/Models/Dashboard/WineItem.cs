using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.Dashboard
{
    public class WineItem
    {
        public long RoomId { get; set; }
        public string  RoomName { get; set; } = null!;
        public int CurrentQuantity { get; set; } = 0;

    }
}
