using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{

    public class IORequestDetail : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; } = string.Empty;
        //FOREIGN KEY + FOREIGN PROPERTIES

        //WINE REFERENCE (NO NEED RELATION)
        public long WineId { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public string WineName { get; set; } = string.Empty;
        public DateTime? MFD { get; set; }
        //ROOM REFERENCE (NO NEED RELATION)
        public long RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        // REQUEST REFERENCE
        public long IORequestId { get; set; }

        public string IORequestCode { get; set; } = string.Empty;
        //CHECKER REFERENCE
        public long CheckerId { get; set; }
        public string CheckerName { get; set; } = string.Empty;

        //WINE_ROOM REFERENCE
        public long WineRoomId { get; set; }

        public IORequest IORequest { get; set; } = null!;


        //REPORT INFORMATION

        public string ReportCode { get; set; } = string.Empty;
        public string? ReportDescription { get; set; } = string.Empty;
        public string ReporterAssigned { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }

    }
}