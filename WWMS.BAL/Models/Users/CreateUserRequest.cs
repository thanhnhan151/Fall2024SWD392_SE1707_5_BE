namespace WWMS.BAL.Models.Users
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = null!;

        // public string Password { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public long RoleId { get; set; }

        // public string? ProfileImageUrl { get; set; }
    }
}
