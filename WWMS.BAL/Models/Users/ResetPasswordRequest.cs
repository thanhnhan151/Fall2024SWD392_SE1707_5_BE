namespace WWMS.BAL.Models.Users
{
    public class ResetPasswordRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
