using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class UpdateProfileModel
    {
        public int UserId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }
        public DateTime Dob { get; set; }
        public String About { get; set; }
        public String Contact { get; set; }
    }
}
