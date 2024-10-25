using WWMS.BAL.Models.Customers;

namespace WWMS.BAL.Interfaces
{
    public interface ICustomerService
    {
        Task<List<GetCustomerResponse>> GetAllAsync();

        Task CreateAsync(CreateCustomerRequest request);
    }
}
