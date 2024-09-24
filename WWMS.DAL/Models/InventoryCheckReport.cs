using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class InventoryCheckReport
{
    public long Id { get; set; }

    public string? ReportDescription { get; set; }

    public int? ItemsChecked { get; set; }

    public int? DiscrepanciesFound { get; set; }

    public string? CheckerName { get; set; }

    public string? CheckerNotes { get; set; }

    public DateTime? CheckStartTime { get; set; }

    public DateTime? CheckEndTime { get; set; }

    public string? ReportStatus { get; set; }

    public string? FileAttachment { get; set; }

    public string? CorrectionPlan { get; set; }

    public string? VerifiedBy { get; set; }

    public DateTime? VerificationDate { get; set; }

    public string? ReportApprovedBy { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public long UserId { get; set; }

    public long InventoryCheckRequestId { get; set; }

    public virtual InventoryCheckRequest InventoryCheckRequest { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
