using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.BAL.Models.IORequestDetails;

namespace WWMS.BAL.Models.IORequests
{
    public class CreateIORequest
    {
        public string RequestCode { get; set; } = null!;
        public int? TotalQuantity { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public string PriorityLevel { get; set; } = string.Empty;
        public long RequesterId { get; set; }
        public string? RequesterName { get; set; }
        public ICollection<CreateIORequestDetail> IORequestDetails { get; set; } = [];
    }
}
