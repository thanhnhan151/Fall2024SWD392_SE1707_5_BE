using WWMS.BAL.Models.Wines;

namespace WWMS.BAL.Interfaces
{
    public interface IWineService
    {
        Task CreateWineAsync(CreateUpdateWineRequest createWineRequest);

        Task<List<GetWineResponse>> GetWineListAsync();

        Task<GetWineDetailResponse?> GetWineByIdAsync(long id);

        Task UpdateWineAsync(long id, CreateUpdateWineRequest updateWineRequest);

        Task DisableWineAsync(long id);
    }
}
