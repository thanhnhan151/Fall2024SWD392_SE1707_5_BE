using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.Dashboard
{
    public class GettMonthQuantity
    {
        public int Month { get; set; }
        public int ImportRequestQuantity { get; set; }
        public int ExportRequestQuantity { get; set; }
        public int overstock { get; set; }
        public int insufficientStock { get; set; }

    }
}
