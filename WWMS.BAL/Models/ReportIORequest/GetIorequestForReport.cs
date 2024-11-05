using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.IORequests;

namespace WWMS.BAL.Models.ReportIORequest
{
    public class GetIorequestForReport
    {
        public string RequestCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }

        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public long? RoomId { get; set; }
        public long? CheckerId { get; set; }
        public long? SuplierId { get; set; }
        public long? CustomerId { get; set; }
        public string Status { get; set; } = string.Empty;

        public ICollection<GetReportIORequest> IORequestDetails { get; set; } = [];
    }
}
