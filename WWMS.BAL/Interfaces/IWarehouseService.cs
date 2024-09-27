using WWMS.BAL.Models.Warehouses;

namespace WWMS.BAL.Interfaces
{
    public interface IWarehouseService
    {
        Task CreateWarehouseAsync(CreateUpdateWarehouseRequest createWarehouseRequest);

        Task<List<GetWarehouseResponse>> GetWarehouseListAsync();

        Task<GetWarehouseResponse?> GetWarehouseByIdAsync(long id);

        Task UpdateWarehouseAsync(CreateUpdateWarehouseRequest updateWarehouseRequest);

        ////Task DisableWarehouseAsync(long id);
    }
}
