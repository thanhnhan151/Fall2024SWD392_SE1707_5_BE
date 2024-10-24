using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("WineRoom")]
    public class WineRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int InitialQuantity { get; set; } = 0;
        public int Import { get; set; } = 0;
        public int Export { get; set; } = 0;
        public int CurrentQuantity { get; set; } = 0;

        public long RoomId { get; set; }
        public virtual Room Room { get; set; } = null!;

        public long WineId { get; set; }
        public virtual Wine Wine { get; set; } = null!;

        public ICollection<CheckRequestDetail> CheckRequestDetails { get; set; } = [];
    }
}