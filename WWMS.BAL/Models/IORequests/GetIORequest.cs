using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.IORequests
{
    public class GetIORequest
    {
        public long Id { get; set; }
        public string RequestCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }// != createdDateTime
        public DateTime? DueDate { get; set; }
        public int? TotalQuantity { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public string PriorityLevel { get; set; } = string.Empty;
        public long RequesterId { get; set; }
        public string? RequesterName { get; set; }
        public ICollection<IORequestDetail> IORequestDetails { get; set; } = [];
    }
}
