using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public long Id { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public virtual ICollection<Wine> Wines { get; set; } = [];
    }
}
