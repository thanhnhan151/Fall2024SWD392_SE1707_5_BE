namespace WWMS.BAL.Models.CheckRequests
{
    public class GetCheckRequestWithDetailsResponse
    {
        public long Id { get; set; }

        public string Purpose { get; set; } = string.Empty;

        public string RequestCode { get; set; } = null!;

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public string? Comments { get; set; }

        public string PriorityLevel { get; set; } = string.Empty;

        //FOREIGN KEY

        public long RequesterId { get; set; }

        public string? RequesterName { get; set; }

        public ICollection<GetCheckRequestDetailListItemResponse> CheckRequestDetails { get; set; } = [];
        public string Status { get; set; }

    }
}