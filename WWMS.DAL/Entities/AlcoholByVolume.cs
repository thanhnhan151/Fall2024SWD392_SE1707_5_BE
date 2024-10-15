using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("AlcoholByVolume")]
    public class AlcoholByVolume
    {
        [Key]
        public long Id { get; set; }

        public string AlcoholByVolumeType { get; set; } = string.Empty;

        public virtual ICollection<Wine> Wines { get; set; } = [];
    }
}
