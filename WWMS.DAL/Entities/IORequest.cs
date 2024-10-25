using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

[Table("IORequest")]
public class IORequest : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string RequestCode { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Comments { get; set; }
    public string IOType { get; set; } = string.Empty;
    public string? SupplierName { get; set; }
    public string? CustomerName { get; set; }
    public string? CheckerName { get; set; }

    public long? RoomId { get; set; }
    public virtual Room Room { get; set; } = null!;

    public long? CheckerId { get; set; }
    public virtual User Checker { get; set; } = null!;

    public long? SuplierId { get; set; }
    public virtual Suplier Suplier { get; set; } = null!;

    public long? CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;

    public ICollection<IORequestDetail> IORequestDetails { get; set; } = [];
}
