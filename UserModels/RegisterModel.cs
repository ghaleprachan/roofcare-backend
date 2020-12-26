using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string UserType { get; set; }
        public string About { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }
}
