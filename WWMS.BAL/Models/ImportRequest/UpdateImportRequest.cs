using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.ImportRequest
{
    public class UpdateImportRequest
    {
        public long Id { get; set; }

        public string RequestCode { get; set; } = null!;

        public string? RequesterName { get; set; }

        public string? Supplier { get; set; }

        public DateTime? ImportDate { get; set; }

        public string? Status { get; set; }

        public int? TotalQuantity { get; set; }

        public decimal? TotalValue { get; set; }

        public string? WarehouseLocation { get; set; }

        public string? TransportDetails { get; set; }

        public string? Comments { get; set; }

        public string? CustomsClearance { get; set; }

        public string? DeliveryStatus { get; set; }

        public DateTime? ExpectedArrival { get; set; }

        public string? InsuranceProvider { get; set; }

        public string? ShippingMethod { get; set; }

        public string? TaxDetails { get; set; }

        public long WineId { get; set; }

        public long UserId { get; set; }

    }
}
