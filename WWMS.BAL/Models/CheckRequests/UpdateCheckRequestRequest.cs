using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.CheckRequests
{
    public class UpdateCheckRequestRequest
    {

        public long Id { get; set; }
        public string Purpose { get; set; }


        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string? Comments { get; set; }

        public string PriorityLevel { get; set; }
    }
}