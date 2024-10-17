using WWMS.BAL.Models.Roles;

namespace WWMS.BAL.Interfaces
{
    public interface IRoleService
    {
        Task<List<GetRoleResponse>> GetAllAsync();
        
        Task CreateAsync(CreateRoleRequest request);
    }
}
