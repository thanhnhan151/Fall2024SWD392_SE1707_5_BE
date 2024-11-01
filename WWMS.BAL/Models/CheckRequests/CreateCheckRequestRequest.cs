namespace WWMS.BAL.Models.CheckRequests
{
    public class CreateCheckRequestRequest
    {
        public string Purpose { get; set; } = string.Empty;
        public string? Comments { get; set; }
        public string PriorityLevel { get; set; } = string.Empty;
        public ICollection<CreateCheckRequestDetailRequest> CreateCheckRequestDetailRequests { get; set; } = [];
    }
}