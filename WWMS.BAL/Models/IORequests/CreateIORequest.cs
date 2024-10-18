using WWMS.BAL.Models.IORequestDetails;

namespace WWMS.BAL.Models.IORequests
{
    public class CreateIORequest
    {
        public string RequestCode { get; set; } = null!;

        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
 //       public int? TotalQuantity { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public string PriorityLevel { get; set; } = string.Empty;
        public long RequesterId { get; set; }
        public string Status { get; set; } = string.Empty;


        public ICollection<CreateIORequestDetail> IORequestDetails { get; set; } = [];
    }
}
