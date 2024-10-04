using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class InventoryCheckRequest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string RequestCode { get; set; } = null!;

    public string? RequesterName { get; set; }

    public DateTime? RequestedAt { get; set; }

    public string? RequestStatus { get; set; }

    public int? TotalItems { get; set; }

    public int? ItemsChecked { get; set; }

    public int? Discrepancies { get; set; }

    public string? CheckerAssigned { get; set; }

    public DateTime? ExpectedCompletionDate { get; set; }

    public string? Comments { get; set; }

    public string? RequestPriority { get; set; }

    public string? AssignedTeam { get; set; }

    public string? CheckPurpose { get; set; }

    public DateTime? Deadline { get; set; }

    public string? Attachments { get; set; }

    public string? AuditReference { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<AdditionalImportRequest> AdditionalImportRequests { get; set; } = [];

    public virtual ICollection<CheckRequestWarehouse> CheckRequestWarehouses { get; set; } = [];

    public virtual Report? Report { get; set; }

    public virtual User User { get; set; } = null!;
}
