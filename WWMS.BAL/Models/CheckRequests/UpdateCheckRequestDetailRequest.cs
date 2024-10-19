using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.CheckRequests
{
    public class UpdateCheckRequestDetailRequest
    {
        public long Id { get; set; }
        public long WineRoomId { get; set; }
        public int ExpectedCurrQuantity { get; set; }
    }
}