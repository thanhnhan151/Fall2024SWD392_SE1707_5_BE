using WWMS.BAL.Models.AlcoholByVolumes;
using WWMS.BAL.Models.BottleSizes;
using WWMS.BAL.Models.Brands;
using WWMS.BAL.Models.Classes;
using WWMS.BAL.Models.Corks;
using WWMS.BAL.Models.Countries;
using WWMS.BAL.Models.Qualifications;
using WWMS.BAL.Models.Tastes;
using WWMS.BAL.Models.WineCategories;

namespace WWMS.BAL.Models.Wines
{
    public class GetWineDetailResponse
    {
        public long Id { get; set; }
        public string WineName { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? MFD { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal ExportPrice { get; set; }
        public GetWineCategoryResponse WineCategory { get; set; } = null!;
        public GetCountryResponse Country { get; set; } = null!;
        public GetTasteResponse Taste { get; set; } = null!;
        public GetClassResponse Class { get; set; } = null!;
        public GetQualificationResponse Qualification { get; set; } = null!;
        public GetCorkResponse Cork { get; set; } = null!;
        public GetBrandResponse Brand { get; set; } = null!;
        public GetBottleSizeResponse BottleSize { get; set; } = null!;
        public GetVolumeResponse AlcoholByVolume { get; set; } = null!;
    }
}
