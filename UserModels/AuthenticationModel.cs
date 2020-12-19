using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class AuthenticationModel
    {
        public bool Success { get; set; }
        public string Message{ get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
        public string UserImage { get; set; }
    }
}
