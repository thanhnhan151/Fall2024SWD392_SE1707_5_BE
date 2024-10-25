using WWMS.BAL.Models.Dashboard;

namespace WWMS.BAL.Interfaces
{
    public interface IDashBoardService
    {
        Task<List<GettMonthQuantity>> GetQuantityPerMonthListAsync(int month, int year);
    }
}
