using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("CheckRequestDetail")]
    public class CheckRequestDetail : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; } = string.Empty;


        //FOREIGN KEY + FOREIGN PROPERTIES

        public long CheckRequestId { get; set; }
        public string CheckRequestCode { get; set; } = string.Empty;

        //WINE REFERENCE (NO NEED RELATION)
        public long WineId { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public string WineName { get; set; } = string.Empty;
        public DateTime? MFD { get; set; }

        //ROOM REFERENCE (NO NEED RELATION)
        public long RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int RoomCapacity { get; set; }

        //CHECKER REFERENCE
        public long CheckerId { get; set; }
        public string CheckerName { get; set; } = string.Empty;

        //WINE_ROOM REFERENCE
        public long WineRoomId { get; set; }
        public int ExpectedCurrQuantity { get; set; }


        public CheckRequest CheckRequest { get; set; } = null!;

        //REPORT INFORMATION

        public string ReportCode { get; set; } = string.Empty;
        public string? ReportDescription { get; set; } = string.Empty;
        public string ReporterAssigned { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }
    }
}