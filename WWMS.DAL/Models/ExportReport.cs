using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class ExportReport
{
    public long Id { get; set; }

    public string? ReportDescription { get; set; }

    public DateTime? ExportDate { get; set; }

    public int? ItemsExported { get; set; }

    public int? DiscrepanciesFound { get; set; }

    public string? ReportPreparedBy { get; set; }

    public DateTime? PreparedAt { get; set; }

    public string? ReportStatus { get; set; }

    public string? FileAttachment { get; set; }

    public string? SignOffBy { get; set; }

    public string? ReviewComments { get; set; }

    public DateTime? FinalApprovalDate { get; set; }

    public string? CustomerFeedback { get; set; }

    public string? ShippingIssues { get; set; }

    public long UserId { get; set; }

    public long ExportRequestId { get; set; }

    public virtual ExportRequest ExportRequest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
