using WWMS.BAL.Models.Wines;

namespace WWMS.BAL.Models.WineCategories
{
    public class GetWineCategoryWithList
    {
        public long Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<GetWineResponse> Wines { get; set; } = [];
    }
}
