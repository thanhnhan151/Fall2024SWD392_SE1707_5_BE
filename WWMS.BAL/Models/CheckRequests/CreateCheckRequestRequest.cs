namespace WWMS.BAL.Models.CheckRequests
{
    public class CreateCheckRequestRequest
    {
        public string Purpose { get; set; } = string.Empty;

        public string RequestCode { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string? Comments { get; set; }

        public string PriorityLevel { get; set; } = string.Empty;

        //GET FROM JWT TOKEN

        public long RequesterId { get; set; }

        public string? RequesterName { get; set; }

        public ICollection<CreateCheckRequestDetailRequest> CreateCheckRequestDetailRequests { get; set; } = [];
    }
}