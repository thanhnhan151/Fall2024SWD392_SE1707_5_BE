using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public long Id { get; set; }

        public string BrandName { get; set; } = string.Empty;

        public virtual ICollection<Wine> Wines { get; set; } = [];
    }
}
