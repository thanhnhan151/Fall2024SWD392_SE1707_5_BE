using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class WineWarehouse
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string WineCode { get; set; } = null!;

    public string? WineName { get; set; }

    public string? WarehouseLocation { get; set; }

    public string? Section { get; set; }

    public string? Rack { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public decimal? StorageTemperature { get; set; }

    public decimal? HumidityLevel { get; set; }

    public string? WineCondition { get; set; }

    public DateTime? ArrivalDate { get; set; }

    public DateTime? DepartureDate { get; set; }

    public DateTime? LastInspectionDate { get; set; }

    public string? InspectionStatus { get; set; }

    public string? HandlingInstructions { get; set; }

    public long WarehouseId { get; set; }

    public long ImportRequestId { get; set; }

    public long WineId { get; set; }

    public virtual ICollection<ExportWineWarehouse> ExportWineWarehouses { get; set; } = [];

    public virtual ImportRequest ImportRequest { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;

    public virtual Wine Wine { get; set; } = null!;
}
