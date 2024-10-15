using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = [];
    }
}
