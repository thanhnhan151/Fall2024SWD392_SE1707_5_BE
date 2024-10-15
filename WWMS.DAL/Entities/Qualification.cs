using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Qualification")]
    public class Qualification
    {
        [Key]
        public long Id { get; set; }

        public string QualificationType { get; set; } = string.Empty;

        public virtual ICollection<Wine> Wines { get; set; } = [];
    }
}
