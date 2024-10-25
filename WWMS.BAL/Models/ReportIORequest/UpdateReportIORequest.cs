namespace WWMS.BAL.Models.ReportIORequest
{
    public class UpdateReportIORequest
    {
        public long Id { get; set; }
        public string ReportCode { get; set; } = string.Empty;
        public string? ReportDescription { get; set; } = string.Empty;
        public string ReporterAssigned { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }

    }
}
