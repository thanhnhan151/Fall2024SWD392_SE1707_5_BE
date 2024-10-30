namespace WWMS.BAL.Models.ReportIORequest
{
    public class CreateReportIORequest
    {
        public long Id { get; set; }

        public string? ReportDescription { get; set; } = string.Empty;
        public string ReporterAssigned { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }


    }
}
