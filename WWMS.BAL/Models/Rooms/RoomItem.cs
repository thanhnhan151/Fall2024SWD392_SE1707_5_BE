namespace WWMS.BAL.Models.Rooms
{
    public class RoomItem
    {
        public long Id { get; set; }
        public int TotalQuantity { get; set; }
        public int Import { get; set; }
        public int Export { get; set; }
        public int CurrrentQuantity { get; set; }
        public long WineId { get; set; }
        public string WineName { get; set; } = string.Empty;
    }
}
