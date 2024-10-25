using WWMS.BAL.Models.Supliers;

namespace WWMS.BAL.Interfaces
{
    public interface ISuplierService
    {
        Task<List<GetSuplierResponse>> GetAllAsync();

        Task CreateAsync(CreateSuplierRequest request);
    }
}
