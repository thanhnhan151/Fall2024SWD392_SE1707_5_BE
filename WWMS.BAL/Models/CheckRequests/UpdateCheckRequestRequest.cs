namespace WWMS.BAL.Models.CheckRequests
{
    public class UpdateCheckRequestRequest
    {
        public long Id { get; set; }
        public string Purpose { get; set; }
        public string? Comments { get; set; }
        public string PriorityLevel { get; set; }
    }
}