using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Suplier")]
    public class Suplier
    {
        [Key]
        public long Id { get; set; }
        public string SuplierName { get; set; } = string.Empty;
        public virtual ICollection<IORequest> IORequests { get; set; } = [];
    }
}
