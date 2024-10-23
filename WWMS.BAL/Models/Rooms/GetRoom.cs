namespace WWMS.BAL.Models.Rooms
{
    public class GetRoom
    {
        public long Id { get; set; }
        public string RoomName { get; set; } = null!;
        public string? LocationAddress { get; set; }
        public int? Capacity { get; set; }
        public int? CurrentOccupancy { get; set; }
        public string? ManagerName { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<GetRoomItemDetails> WineRooms { get; set; } = [];
    }
}
