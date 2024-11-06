namespace WWMS.BAL.Models.Dashboard
{
    public class WineItem
    {
        public long RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public int CurrentQuantity { get; set; } = 0;

    }
}
