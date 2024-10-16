namespace WWMS.BAL.Models.Wines
{
    public class GetWineDetailResponse
    {
        public long Id { get; set; }
        public string WineName { get; set; } = null!;
        public int? AvailableStock { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public DateTime? MFD { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal ExportPrice { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Taste { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;
        public string Cork { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string BottleSize { get; set; } = string.Empty;
        public string AlcoholByVolume { get; set; } = string.Empty;
    }
}
