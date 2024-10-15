namespace WWMS.BAL.Models.Wines
{
    public class GetWineResponse
    {
        public long Id { get; set; }
        public string WineName { get; set; } = null!;
        public decimal? AlcoholContent { get; set; }
        public string? BottleSize { get; set; }
        public int? AvailableStock { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string Supplier { get; set; } = string.Empty;
        public DateTime? MFD { get; set; }
        public string Status { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
