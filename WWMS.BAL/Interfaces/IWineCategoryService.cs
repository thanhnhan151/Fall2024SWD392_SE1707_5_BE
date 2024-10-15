using WWMS.BAL.Models.WineCategories;

namespace WWMS.BAL.Interfaces
{
    public interface IWineCategoryService
    {
        Task CreateWineCategoryAsync(CreateWineCategoryRequest createWineCategoryRequest);

        Task<List<GetWineCategoryResponse>> GetWineCategoryListAsync();

        Task<GetWineCategoryWithList?> GetAllWinesByWineCategoryIdAsync(long id);
    }
}
