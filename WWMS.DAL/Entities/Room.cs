using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

[Table("Room")]
public class Room : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string RoomName { get; set; } = null!;
    public string LocationAddress { get; set; } = string.Empty;
    public int Capacity { get; set; } //MAX SIZE
    public int CurrentOccupancy { get; set; } = 0;
    public string ManagerName { get; set; } = string.Empty;

    public ICollection<IORequest> IORequests { get; set; } = [];
    public ICollection<WineRoom> WineRooms { get; set; } = [];
}
