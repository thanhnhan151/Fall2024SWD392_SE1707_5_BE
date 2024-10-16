using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public long Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = [];
    }
}
