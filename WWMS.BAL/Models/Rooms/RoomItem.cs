namespace WWMS.BAL.Models.Rooms
{
    public class RoomItem
    {
        public long Id { get; set; }
        public int InitialQuantity { get; set; } = 0;
        public int Import { get; set; } = 0;
        public int Export { get; set; } = 0;
        public int CurrentQuantity { get; set; } = 0;
        public long WineId { get; set; }
        public string WineName { get; set; } = string.Empty;
    }
}
