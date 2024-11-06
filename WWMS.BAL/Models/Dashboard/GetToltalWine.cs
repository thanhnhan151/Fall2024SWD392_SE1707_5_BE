namespace WWMS.BAL.Models.Dashboard
{
    public class GetToltalWine
    {
        public long Id { get; set; }
        public string WineName { get; set; } = null!;
        public string? CategoryName { get; set; }
        public int ToltalQuantity { get; set; } = 0;
        public ICollection<WineItem> WineRooms { get; set; } = [];
    }
}
