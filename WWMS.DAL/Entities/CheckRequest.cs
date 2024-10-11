using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class CheckRequest : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Purpose { get; set; }
    public string RequestCode { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Comments { get; set; }
    public string PriorityLevel { get; set; }

    //FOREIGN KEY

    public long RequesterId { get; set; }
    public string? RequesterName { get; set; }

     public ICollection<CheckRequestDetail> CheckRequestDetails { get; set; }









}
