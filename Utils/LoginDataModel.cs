using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightE2ETest.Utils
{
    public class LoginDataModel
    {
        public string? Username { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public bool ShouldLogin { get; set; }
    }
}
