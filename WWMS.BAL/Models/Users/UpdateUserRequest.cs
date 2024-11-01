﻿namespace WWMS.BAL.Models.Users
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string ProfileImageUrl { get; set; } = string.Empty;
    }
}
