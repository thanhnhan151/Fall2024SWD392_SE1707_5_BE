namespace WWMS.BAL.Models.Wines
{
    public class CreateUpdateWineRequest
    {
        public string WineName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? MFD { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal ExportPrice { get; set; }
        public long WineCategoryId { get; set; }
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
