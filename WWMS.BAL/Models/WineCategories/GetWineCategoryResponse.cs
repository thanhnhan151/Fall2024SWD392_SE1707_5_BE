namespace WWMS.BAL.Models.WineCategories
{
    public class GetWineCategoryResponse
    {
        public long Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string WineType { get; set; } = string.Empty;
    }
}
