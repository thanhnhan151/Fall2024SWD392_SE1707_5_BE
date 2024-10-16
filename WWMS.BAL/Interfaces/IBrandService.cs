using WWMS.BAL.Models.Brands;

namespace WWMS.BAL.Interfaces
{
    public interface IBrandService
    {
        Task<List<GetBrandResponse>> GetAllAsync();
        Task CreateAsync(CreateBrandRequest request);
    }
}
