using WWMS.BAL.Models.Users;

namespace WWMS.BAL.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest createUserRequest);

        Task<List<GetUserResponse>> GetUserListAsync();

        Task<GetUserResponse?> GetUserByIdAsync(long id);

        Task UpdateUserAsync(UpdateUserRequest updateUserRequest);

        Task DisableUserAsync(long id);

        Task<GetUserResponse?> LoginAsync(string username, string password);

        Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest);
    }
}
