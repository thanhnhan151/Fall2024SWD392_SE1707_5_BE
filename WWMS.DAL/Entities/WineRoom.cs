using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("WineRoom")]
    public class WineRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int TotalQuantity { get; set; }
        public int CurrentQuantity { get; set; }

        public long RoomId { get; set; }
        public virtual Room Room { get; set; } = null!;

        public long WineId { get; set; }
        public virtual Wine Wine { get; set; } = null!;

        public ICollection<CheckRequestDetail> CheckRequestDetails { get; set; } = [];      
    }
}