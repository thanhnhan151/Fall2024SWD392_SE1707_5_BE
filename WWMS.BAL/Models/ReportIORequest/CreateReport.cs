using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.IORequests;

namespace WWMS.BAL.Models.ReportIORequest
{
    public class CreateReport
    {
        public ICollection<CreateReportIORequest> IORequestDetails { get; set; } = [];
    }
}
