using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.IORequests.IOrequestdetails
{
    public class UpdateDetailsById
    {
        public ICollection<UpdateIORequestDetail> UpIORequestDetails { get; set; } = [];
    }
}
