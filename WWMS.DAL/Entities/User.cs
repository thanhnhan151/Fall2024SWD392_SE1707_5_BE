using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public string? ProfileImageUrl { get; set; }

    public string? AccountStatus { get; set; } = "Active";

    public virtual ICollection<AdditionalImportRequest> AdditionalImportRequests { get; set; } = [];

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = [];

    public virtual ICollection<ExportRequest> ExportRequests { get; set; } = [];

    public virtual ICollection<ImportRequest> ImportRequests { get; set; } = [];

    public virtual ICollection<InventoryCheckRequest> InventoryCheckRequests { get; set; } = [];

    public virtual ICollection<Report> Reports { get; set; } = [];
}
