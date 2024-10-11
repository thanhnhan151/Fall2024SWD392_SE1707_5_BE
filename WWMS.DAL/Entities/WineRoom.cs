using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.DAL.Entities
{
    public class WineRoom : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int CurrQuantity { get; set; }
        public int TotalQuantity { get; set; }
        //FOREIGN KEY
        public long RoomId { get; set; }
        public long WineId { get; set; }

        public ICollection<IORequestDetail> IORequestDetails { get; set; } = [];
        public ICollection<CheckRequestDetail> CheckRequestDetails { get; set; } = [];

        public Room Room { get; set; } = null!;

        public Wine Wine { get; set; } = null!;

    }
}