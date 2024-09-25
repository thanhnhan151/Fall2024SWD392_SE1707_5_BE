namespace WWMS.BAL.Models.Users
{
    public class UpdateUserRequest
    {
        public long Id { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Role { get; set; }

        public string? Status { get; set; }

        public string? ProfileImageUrl { get; set; }

        public string? Bio { get; set; }
    }
}
