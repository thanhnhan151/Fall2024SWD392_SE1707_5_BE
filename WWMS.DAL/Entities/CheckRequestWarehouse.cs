using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class CheckRequestWarehouse
{
    public long Id { get; set; }

    public string RequestCode { get; set; } = null!;

    public string? WarehouseName { get; set; }

    public DateTime? RequestedAt { get; set; }

    public string? RequestStatus { get; set; }

    public int? TotalItems { get; set; }

    public int? ItemsChecked { get; set; }

    public int? Discrepancies { get; set; }

    public string? CheckerAssigned { get; set; }

    public DateTime? ExpectedCompletionDate { get; set; }

    public string? Comments { get; set; }

    public long WarehouseId { get; set; }

    public long InventoryCheckRequestId { get; set; }

    public virtual InventoryCheckRequest InventoryCheckRequest { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
