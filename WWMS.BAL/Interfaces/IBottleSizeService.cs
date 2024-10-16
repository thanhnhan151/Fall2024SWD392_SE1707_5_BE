using WWMS.BAL.Models.BottleSizes;

namespace WWMS.BAL.Interfaces
{
    public interface IBottleSizeService
    {
        Task<List<GetBottleSizeResponse>> GetAllAsync();
        Task CreateAsync(CreateBottleSizeRequest request);
    }
}
