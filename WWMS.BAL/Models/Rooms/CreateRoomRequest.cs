namespace WWMS.BAL.Models.Rooms
{
    public class CreateRoomRequest
    {
        public string RoomName { get; set; } = null!;
        public string? LocationAddress { get; set; }
        public int? Capacity { get; set; }
        public int? CurrentOccupancy { get; set; }
        public string? ManagerName { get; set; }
        public ICollection<RoomItem> WineRooms { get; set; } = [];
    }
}
