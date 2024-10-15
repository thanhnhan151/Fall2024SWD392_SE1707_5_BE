using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Taste")]
    public class Taste
    {
        [Key]
        public long Id { get; set; }

        public string TasteType { get; set; } = string.Empty;

        public virtual ICollection<Wine> Wines { get; set; } = [];
    }
}
