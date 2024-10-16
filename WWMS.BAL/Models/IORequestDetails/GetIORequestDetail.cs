using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.IORequestDetails
{
    public class GetIORequestDetail
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public string Comments { get; set; } = string.Empty;
        public long WineId { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public DateTime? MFD { get; set; }
        public long RoomId { get; set; }
        public long IORequestId { get; set; }
        public long CheckerId { get; set; }
        public long WineRoomId { get; set; }

        public string Status { get; set; } = string.Empty;


        //REPORT INFORMATION

        public string ReportCode { get; set; } = string.Empty;
        public string? ReportDescription { get; set; } = string.Empty;
        public string ReporterAssigned { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }


    }
}
