using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.WineRoom
{
    public class UpdateWineRoom
    {
        public long Id { get; set; }
        public int CurrQuantity { get; set; }
        public int TotalQuantity { get; set; }
        //FOREIGN KEY
        public long RoomId { get; set; }
        public long WineId { get; set; }

    }
}
