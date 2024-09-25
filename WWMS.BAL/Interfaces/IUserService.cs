using WWMS.BAL.Models.Users;

namespace WWMS.BAL.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUserResponse>> GetUserListAsync();
    }
}
