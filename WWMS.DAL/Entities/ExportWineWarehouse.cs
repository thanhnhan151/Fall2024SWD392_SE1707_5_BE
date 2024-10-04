using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class ExportWineWarehouse
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long ExportRequestId { get; set; }

    public long WineWarehouseId { get; set; }

    public virtual ExportRequest ExportRequest { get; set; } = null!;

    public virtual WineWarehouse WineWarehouse { get; set; } = null!;
}
