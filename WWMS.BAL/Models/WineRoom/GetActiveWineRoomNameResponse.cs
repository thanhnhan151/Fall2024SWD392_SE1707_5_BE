namespace WWMS.BAL.Models.WineRoom
{
    public class GetActiveWineRoomNameResponse
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public long WineId { get; set; }
        public string WineName { get; set; }
    }
}