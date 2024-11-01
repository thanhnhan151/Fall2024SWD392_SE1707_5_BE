using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WWMS.BAL.Models.Users
{
    public class UpdatePasswordRequest
    {
        public string NewPass { get; set; } = null!;
        public string OldPass { get; set; } = null!;
    }
}