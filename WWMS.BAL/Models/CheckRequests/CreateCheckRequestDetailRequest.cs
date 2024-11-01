namespace WWMS.BAL.Models.CheckRequests
{
    public class CreateCheckRequestDetailRequest
    {
        public string Purpose { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; } = string.Empty;

        //CHECKER REFERENCE
        public long CheckerId { get; set; }

        //WINE_ROOM REFERENCE
        public long WineRoomId { get; set; }

    }
}