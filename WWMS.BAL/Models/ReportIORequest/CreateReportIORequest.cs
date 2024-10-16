using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.ReportIORequest
{
    public class CreateReportIORequest
    {
        public string ReportCode { get; set; } = string.Empty;
        public string? ReportDescription { get; set; } = string.Empty;
        public string ReporterAssigned { get; set; } = string.Empty;
        public int? DiscrepanciesFound { get; set; }
        public int ActualQuantity { get; set; }
        public string? ReportFile { get; set; }
    }
}
