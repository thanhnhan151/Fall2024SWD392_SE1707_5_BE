using WWMS.BAL.Models.Tastes;

namespace WWMS.BAL.Interfaces
{
    public interface ITasteService
    {
        Task<List<GetTasteResponse>> GetAllAsync();
        Task CreateAsync(CreateTasteRequest request);
    }
}
