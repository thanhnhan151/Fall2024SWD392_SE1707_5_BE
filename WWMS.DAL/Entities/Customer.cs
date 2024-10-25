using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public long Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public virtual ICollection<IORequest> IORequests { get; set; } = [];
    }
}
