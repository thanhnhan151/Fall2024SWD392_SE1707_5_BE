namespace WWMS.DAL.Entities;

public partial class AuditLog
{
    public long Id { get; set; }

    public string? ActionType { get; set; }

    public string? ActionDescription { get; set; }

    public DateTime? PerformedAt { get; set; }

    public string? IpAddress { get; set; }

    public string? DeviceDetails { get; set; }

    public string? RequestMethod { get; set; }

    public string? ResponseStatus { get; set; }

    public int? DurationMs { get; set; }

    public string? RequestUrl { get; set; }

    public decimal? ResponseTime { get; set; }

    public string? ErrorDetails { get; set; }

    public long? ResponseSize { get; set; }

    public string? SessionId { get; set; }

    public string? Location { get; set; }

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
