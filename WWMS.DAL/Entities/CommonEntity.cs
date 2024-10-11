using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.DAL.Entities
{
    public class CommonEntity
    {
        public DateTime? createdTime { get; set; }
        public DateTime? updatedTime { get; set; }
        public DateTime? deletedTime { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }
        public string deletedBy { get; set; }
        public string Status { get; set; }

    }
}