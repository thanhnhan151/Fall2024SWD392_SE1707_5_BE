namespace WWMS.BAL.Models.CheckRequests
{
    public class UpdateCheckRequestDetailRequest
    {
        public long Id { get; set; }
        public long WineRoomId { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        //CHECKER REFERENCE
        public long CheckerId { get; set; }
        public string Comments { get; set; } = string.Empty;

    }
}