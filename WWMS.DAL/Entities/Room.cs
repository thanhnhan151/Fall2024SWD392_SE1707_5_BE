using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class Room : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string RoomName { get; set; } = null!;
    public string? LocationAddress { get; set; }
    public int? Capacity { get; set; } //MAX SIZE
    public int? CurrentOccupancy { get; set; }
    public string? ManagerName { get; set; }
    public ICollection<WineRoom> WineRooms { get; set; } = [];
}
