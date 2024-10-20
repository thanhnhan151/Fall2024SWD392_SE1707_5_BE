using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.CheckRequestReports
{
    public class CreateCheckRequestReportRequest
    {
        public long CheckRequestDetailId { get; set; }
        public string? ReportDescription { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }
    }
}