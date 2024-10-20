using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.CheckRequests
{
    public class GetCheckRequestResponse
    {
        public long Id { get; set; }

        public string Purpose { get; set; }

        public string RequestCode { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string? Comments { get; set; }

        public string PriorityLevel { get; set; }

        public long RequesterId { get; set; }
        public string? RequesterName { get; set; }
        public int NoOfDetails { get; set; }
        public string Status
         { get; set; }

    }
}