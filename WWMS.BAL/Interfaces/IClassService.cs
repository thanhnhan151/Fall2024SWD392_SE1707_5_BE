using WWMS.BAL.Models.Classes;

namespace WWMS.BAL.Interfaces
{
    public interface IClassService
    {
        Task<List<GetClassResponse>> GetAllAsync();
        Task CreateAsync(CreateClassRequest request);
    }
}
