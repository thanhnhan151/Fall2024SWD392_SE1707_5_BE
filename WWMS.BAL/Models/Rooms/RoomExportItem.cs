namespace WWMS.BAL.Models.Rooms
{
    public class RoomExportItem
    {
        public long WineId { get; set; }
        public int CurrentQuantity { get; set; }
        public string WineName { get; set; } = string.Empty;
    }
}
