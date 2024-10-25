namespace WWMS.BAL.Models.CheckRequestReports
{
    public class UpdateCheckRequestReportRequest
    {
        public long CheckRequestDetailId { get; set; }
        public string? ReportDescription { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }
    }
}