﻿namespace WWMS.BAL.Models.Rooms
{
    public class CreateRoomRequest
    {
        public string RoomName { get; set; } = null!;
        public string? LocationAddress { get; set; }
        public int? Capacity { get; set; }
    }
}
