namespace WWMS.BAL.Models.WineCategories
{
    public class CreateWineCategoryRequest
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string WineType { get; set; } = string.Empty;
    }
}
