using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.DAL.Entities
{
    [Table("CodeResetPass")]
    public class CodeResetPass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CodeVerified { get; set; } = null!;
        public string Username { get; set; } = null!;
        public bool IsUsable { get; set; } = true;
        public DateTime createdTime { get; set; } = DateTime.Now;

    }
}