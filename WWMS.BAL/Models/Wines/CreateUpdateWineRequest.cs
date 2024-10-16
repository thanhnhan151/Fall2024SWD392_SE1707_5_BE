namespace WWMS.BAL.Models.Wines
{
    public class CreateUpdateWineRequest
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
        public long CategoryId { get; set; }
        public long CountryId { get; set; }
        public long TasteId { get; set; }
        public long ClassId { get; set; }
        public long QualificationId { get; set; }
        public long CorkId { get; set; }
        public long BrandId { get; set; }
        public long BottleSizeId { get; set; }
        public long AlcoholByVolumeId { get; set; }
    }
}
