using WWMS.BAL.Models.Countries;

namespace WWMS.BAL.Interfaces
{
    public interface ICountryService
    {
        Task<List<GetCountryResponse>> GetAllAsync();
        Task CreateAsync(CreateCountryRequest request);
    }
}
