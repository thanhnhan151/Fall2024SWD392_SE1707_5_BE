namespace WWMS.BAL.Models.Users
{
    public class GetUserResponse
    {
        public long Id { get; set; }

        public string Username { get; set; } = null!;

        //public string PasswordHash { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string Role { get; set; } = string.Empty;

        //public string? ProfileImageUrl { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
