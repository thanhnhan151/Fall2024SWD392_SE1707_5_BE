using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.Dashboard
{
    public class GettMonthQuantityIO
    {
        public int Month { get; set; }
        public int ImportMonthQuantity { get; set; }
        public int ExportMonthQuantity { get; set; }
    }
}
