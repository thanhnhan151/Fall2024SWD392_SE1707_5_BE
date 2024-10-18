using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.Users
{
    public class SendCodeResetPassRequest
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}