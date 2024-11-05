using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.ReportIORequest;

namespace WWMS.BAL.Models.Dashboard
{
    public  class GetToltalWine
    {
        public long Id { get; set; }
        public string WineName { get; set; } = null!;
        public int ToltalQuantity { get; set; } = 0;
        public ICollection<WineItem> WineRooms { get; set; } = [];
    }
}
