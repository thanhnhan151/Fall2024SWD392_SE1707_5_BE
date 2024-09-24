using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class User
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Role { get; set; }

    public string? Status { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? ProfileImageUrl { get; set; }

    public string? Bio { get; set; }

    public DateTime? LastPasswordChange { get; set; }

    public string? AccountStatus { get; set; }

    public string? PreferredLanguage { get; set; }

    public string? TimeZone { get; set; }

    public virtual ICollection<AdditionalImportRequest> AdditionalImportRequests { get; set; } = new List<AdditionalImportRequest>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<ExportRequest> ExportRequests { get; set; } = new List<ExportRequest>();

    public virtual ICollection<ImportRequest> ImportRequests { get; set; } = new List<ImportRequest>();

    public virtual ICollection<InventoryCheckRequest> InventoryCheckRequests { get; set; } = new List<InventoryCheckRequest>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
