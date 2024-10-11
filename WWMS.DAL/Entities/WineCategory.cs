using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.DAL.Entities
{
    public class WineCategory : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string WineType { get; set; }
        public ICollection<Wine> Wines { get; set; }
    }
}