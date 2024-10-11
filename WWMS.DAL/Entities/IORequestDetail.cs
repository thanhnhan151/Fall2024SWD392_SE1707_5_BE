using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.DAL.Entities
{

    public class IORequestDetail : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }
        //FOREIGN KEY + FOREIGN PROPERTIES

        //WINE REFERENCE (NO NEED RELATION)
        public long WineId { get; set; }
        public string Supplier { get; set; }
        public string WineName { get; set; }
        public DateTime? MFD { get; set; }
        //ROOM REFERENCE (NO NEED RELATION)
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        // REQUEST REFERENCE
        public long IORequestId { get; set; }

        public string IORequestCode { get; set; }
        //CHECKER REFERENCE
        public long CheckerId { get; set; }
        public string CheckerName { get; set; }

        //WINE_ROOM REFERENCE
        public long WineRoomId { get; set; }

        public IORequest IORequest { get; set; }


        //REPORT INFORMATION

        public string ReportCode { get; set; }
        public string? ReportDescription { get; set; }
        public string ReporterAssigned { get; set; }
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }

    }
}