namespace WWMS.BAL.Models.CheckRequests
{
    public class GetCheckRequestDetailListItemResponse
    {
        public long Id { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public long CheckRequestId { get; set; }
        public long WineId { get; set; }
        public string WineName { get; set; } = string.Empty;
        public DateTime? MFD { get; set; }

        //ROOM REFERENCE (NO NEED RELATION)
        public long RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;

        //CHECKER REFERENCE
        public long CheckerId { get; set; }
        public string CheckerName { get; set; } = string.Empty;

        //WINE_ROOM REFERENCE
        public long WineRoomId { get; set; }
        public int ExpectedCurrQuantity { get; set; }
    }
}