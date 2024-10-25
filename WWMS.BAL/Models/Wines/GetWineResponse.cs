namespace WWMS.BAL.Models.Wines
{
    public class GetWineResponse
    {
        public long Id { get; set; }
        public string WineName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? MFD { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal ExportPrice { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
