using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class AdminLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AdminRegister
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
