using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.Users
{
    public class GetStaffResponse
    {
        public long Id { get; set; }

        public string Username { get; set; } = null!;

        //public string PasswordHash { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}