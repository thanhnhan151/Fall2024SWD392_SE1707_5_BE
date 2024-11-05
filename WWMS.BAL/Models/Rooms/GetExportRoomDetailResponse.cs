namespace WWMS.BAL.Models.Rooms
{
    public class GetExportRoomDetailResponse
    {
        public long Id { get; set; }
        public ICollection<RoomExportItem> WineRooms { get; set; } = [];
    }
}
