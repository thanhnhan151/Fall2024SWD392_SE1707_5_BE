using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("IORequestDetail")]
    public class IORequestDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int Quantity { get; set; }

        public long WineId { get; set; }
        public virtual Wine Wine { get; set; } = null!;

        public long IORequestId { get; set; }
        public virtual IORequest IORequest { get; set; } = null!;

        //REPORT INFORMATION
        //public string ReportCode { get; set; } = string.Empty;
        //public string? ReportDescription { get; set; } = string.Empty;
        //public string ReporterAssigned { get; set; } = string.Empty;
        //public int? DiscrepanciesFound { get; set; }
        //public int ActualQuantity { get; set; }
        //public string? ReportFile { get; set; }
    }
}