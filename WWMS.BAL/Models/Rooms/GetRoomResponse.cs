namespace WWMS.BAL.Models.Rooms
{
    public class GetRoomResponse
    {
        public long Id { get; set; }
        public string RoomName { get; set; } = null!;
        public string LocationAddress { get; set; } = string.Empty;
        public int? Capacity { get; set; }
        public int? CurrentOccupancy { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
