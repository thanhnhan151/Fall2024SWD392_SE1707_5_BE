using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("BottleSize")]
    public class BottleSize
    {
        [Key]
        public long Id { get; set; }

        public string BottleSizeType { get; set; } = string.Empty;

        public virtual ICollection<Wine> Wines { get; set; } = [];
    }
}
