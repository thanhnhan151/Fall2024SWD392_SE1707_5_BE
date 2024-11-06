using WWMS.BAL.Models.Dashboard;

namespace WWMS.BAL.Interfaces
{
    public interface IDashBoardService
    {
        Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync(int year);

        Task<List<GettMonthQuantityIO>> GetQuantityPerMonthIOListAsync(int year);

        Task<List<GetToltalWine>> GetQuantityWineListAsync();

        Task<List<GetToltalWineCategory>> GetQuantityWineListCategoryAsync();
    }
}
