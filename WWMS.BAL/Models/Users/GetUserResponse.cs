namespace WWMS.BAL.Models.Users
{
    public class GetUserResponse
    {
        public long Id { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string Role { get; set; } = string.Empty;

        public string? Status { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Bio { get; set; }

        public DateTime? LastPasswordChange { get; set; }

        public string AccountStatus { get; set; } = string.Empty;

        public string? PreferredLanguage { get; set; }

        public string? TimeZone { get; set; }
    }
}
