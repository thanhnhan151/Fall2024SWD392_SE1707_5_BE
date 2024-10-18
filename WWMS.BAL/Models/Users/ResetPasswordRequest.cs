namespace WWMS.BAL.Models.Users
{
    public class ResetPasswordRequest
    {
        public string Username { get; set; } = string.Empty;
        public string NewPass { get; set; } = string.Empty;
    }
}
