using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class IORequest : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string RequestCode { get; set; } = null!;
    public DateTime? StartDate { get; set; }// != createdDateTime
    public DateTime? DueDate { get; set; }
    public int? TotalQuantity { get; set; }
    public string? Comments { get; set; }
    public string IOType { get; set; } = string.Empty;
    public string PriorityLevel { get; set; } = string.Empty;

    //FOREIGN KEY - FOREIGN PROPERTIES
    public long RequesterId { get; set; }
    public string? RequesterName { get; set; }

    public ICollection<IORequestDetail> IORequestDetails { get; set; } = [];
    

}
