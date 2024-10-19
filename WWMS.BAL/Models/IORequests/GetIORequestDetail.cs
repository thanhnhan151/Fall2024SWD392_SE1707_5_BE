using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.IORequests
{
    public class GetIORequestDetail
    {

        public long Id { get; set; }

        public int Quantity { get; set; }

        public long WineId { get; set; }

        public long IORequestId { get; set; }



        //REPORT INFORMATION

        //public string ReportCode { get; set; } = string.Empty;
        //public string? ReportDescription { get; set; } = string.Empty;
        //public string ReporterAssigned { get; set; } = string.Empty;
        //public int? DiscrepanciesFound { get; set; }
        //public int ActualQuantity { get; set; }
        //public string? ReportFile { get; set; }


    }
}
