using WWMS.BAL.Models.Users;

namespace WWMS.BAL.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest createUserRequest);

        Task<List<GetUserResponse>> GetUserListAsync();
        Task<List<GetStaffResponse>> GetStaffAsync();


        Task<GetUserResponse?> GetUserByIdAsync(long id);

        Task UpdateUserAsync(long id, UpdateUserRequest updateUserRequest);

        Task DisableUserAsync(long id);

        Task<GetUserResponse?> LoginAsync(string username, string password);

        Task ResetPasswordAsync(ResetPasswordRequest resetPasswordRequest);

        Task UpdatePasswordAsync(UpdatePasswordRequest updatePasswordRequest);

        Task SendCodeResetPassAsync(SendCodeResetPassRequest sendCodeResetPassRequest);
    }
}
