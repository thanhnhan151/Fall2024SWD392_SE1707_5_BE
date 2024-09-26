namespace WWMS.BAL.Models.ImportRequests
{
    public class CreateImportRequest
    {
        public long Id { get; set; }

        public string? RequesterName { get; set; }

        public string? Supplier { get; set; }

        public int? TotalQuantity { get; set; }

        public string? WarehouseLocation { get; set; }

        public string? TransportDetails { get; set; }

        public string? Comments { get; set; }

        public string? CustomsClearance { get; set; }

        public DateTime? ExpectedArrival { get; set; }

        public string? InsuranceProvider { get; set; }

        public string? ShippingMethod { get; set; }

        public string? TaxDetails { get; set; }

        public long WineId { get; set; }

        public long UserId { get; set; }
    }
}
