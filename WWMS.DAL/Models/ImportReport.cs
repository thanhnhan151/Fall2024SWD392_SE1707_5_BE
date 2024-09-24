using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class ImportReport
{
    public long Id { get; set; }

    public string? ReportDescription { get; set; }

    public DateTime? ImportDate { get; set; }

    public int? ItemsImported { get; set; }

    public int? DiscrepanciesFound { get; set; }

    public string? ReportPreparedBy { get; set; }

    public DateTime? PreparedAt { get; set; }

    public string? ReportStatus { get; set; }

    public string? FileAttachment { get; set; }

    public string? SignOffBy { get; set; }

    public string? ReviewComments { get; set; }

    public DateTime? FinalApprovalDate { get; set; }

    public string? SupplierFeedback { get; set; }

    public string? DamageReport { get; set; }

    public long ImportRequestId { get; set; }

    public long UserId { get; set; }

    public virtual ImportRequest ImportRequest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
