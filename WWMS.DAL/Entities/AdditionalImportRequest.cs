using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class AdditionalImportRequest
{
    public long Id { get; set; }

    public string RequestCode { get; set; } = null!;

    public string? RequesterName { get; set; }

    public string? Supplier { get; set; }

    public DateTime? ImportDate { get; set; }

    public string? Status { get; set; }

    public int? AdditionalQuantity { get; set; }

    public decimal? TotalValue { get; set; }

    public string? WarehouseLocation { get; set; }

    public string? TransportDetails { get; set; }

    public string? Comments { get; set; }

    public long ExportRequestId { get; set; }

    public long InventoryCheckRequestId { get; set; }

    public long UserId { get; set; }

    public long ImportRequestId { get; set; }

    public virtual ExportRequest ExportRequest { get; set; } = null!;

    public virtual ImportRequest ImportRequest { get; set; } = null!;

    public virtual InventoryCheckRequest InventoryCheckRequest { get; set; } = null!;

    public virtual Report? Report { get; set; }

    public virtual User User { get; set; } = null!;
}
