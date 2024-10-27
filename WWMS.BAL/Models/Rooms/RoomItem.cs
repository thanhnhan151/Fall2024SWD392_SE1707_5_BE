using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.Rooms
{
    public class RoomItem
    {
        public long Id { get; set; }
        public int InitialQuantity { get; set; } = 0;
        public int Import { get; set; } = 0;
        public int Export { get; set; } = 0;
        public int CurrentQuantity { get; set; } = 0;

        public long RoomId { get; set; }

        public long WineId { get; set; }
    }
}
