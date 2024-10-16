using WWMS.BAL.Models.AlcoholByVolumes;

namespace WWMS.BAL.Interfaces
{
    public interface IAlcoholByVolumeService
    {
        Task<List<GetVolumeResponse>> GetAllAsync();
        Task CreateAsync(CreateVolumeRequest request);
    }
}
