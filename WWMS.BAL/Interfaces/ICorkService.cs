using WWMS.BAL.Models.Corks;

namespace WWMS.BAL.Interfaces
{
    public interface ICorkService
    {
        Task<List<GetCorkResponse>> GetAllAsync();
        Task CreateAsync(CreateCorkRequest request);
    }
}
