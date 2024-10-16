namespace WWMS.BAL.Models.Users
{
    public class UpdateUserRequest
    {
        public long Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
