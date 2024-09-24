namespace WWMS.DAL.Entities;

public partial class ExportWineWarehouse
{
    public long Id { get; set; }

    public long ExportRequestId { get; set; }

    public long WineWarehouseId { get; set; }

    public virtual ExportRequest ExportRequest { get; set; } = null!;

    public virtual WineWarehouse WineWarehouse { get; set; } = null!;
}
