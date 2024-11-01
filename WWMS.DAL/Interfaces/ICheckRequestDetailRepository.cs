using WWMS.DAL.Entities;
using WWMS.DAL.Infrastructures;

namespace WWMS.DAL.Interfaces
{
    public interface ICheckRequestDetailRepository : IGenericRepository<CheckRequestDetail>
    {
        Task<ICollection<CheckRequestDetail>> GetAllByChecKerIdAsync(long checkerId);
        Task<ICollection<CheckRequestDetail>> GetAllCheckRequestDetailsByReporterNameAsync(string reporterName);

        Task<(int totalPositive, int totalNegative)> GetQuantityByMonthAndYearAsync(int month, int year);
    }
}