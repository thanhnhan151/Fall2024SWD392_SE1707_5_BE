namespace WWMS.BAL.Models.Rooms
{
    public class GetRoomItemDetails
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public long RoomId { get; set; }
        public long WineId { get; set; }
    }
}
