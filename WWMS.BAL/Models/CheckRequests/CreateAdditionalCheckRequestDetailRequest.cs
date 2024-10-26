using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.CheckRequests
{
    public class CreateAdditionalCheckRequestDetailRequest
    {
        public string Purpose { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; } = string.Empty;
        public long CheckRequestId { get; set; }

        public string CheckRequestCode { get; set; }


        //CHECKER REFERENCE
        public long CheckerId { get; set; }

        //WINE_ROOM REFERENCE
        public long WineRoomId { get; set; }
    }
}