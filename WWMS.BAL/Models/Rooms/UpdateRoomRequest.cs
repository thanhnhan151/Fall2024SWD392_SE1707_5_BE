namespace WWMS.BAL.Models.Rooms
{
    public class UpdateRoomRequest
    {
        public string RoomName { get; set; } = null!;
        public string LocationAddress { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
