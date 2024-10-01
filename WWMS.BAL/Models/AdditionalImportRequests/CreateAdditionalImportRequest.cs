namespace WWMS.BAL.Models.AdditionalImportRequests
{
    public class CreateAdditionalImportRequest
    {
        public long Id { get; set; }

        public string? RequesterName { get; set; }

        public string? Supplier { get; set; }

        public int? AdditionalQuantity { get; set; }

        public decimal? TotalValue { get; set; }

        public string? WarehouseLocation { get; set; }

        public string? TransportDetails { get; set; }

        public string? Comments { get; set; }

        public long ExportRequestId { get; set; }

        public long InventoryCheckRequestId { get; set; }

        public long UserId { get; set; }

        public long ImportRequestId { get; set; }
    }
}
