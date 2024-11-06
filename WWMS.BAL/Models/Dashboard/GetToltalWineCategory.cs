using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.Dashboard
{
    public class GetToltalWineCategory
    {
        public string? CategoryName { get; set; }
        public int ToltalQuantity { get; set; } = 0;
    }
}
