using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class UserProfession
    {
        public int UserProfessionId { get; set; }
        public int UserId { get; set; }
        public int ProfessionId { get; set; }
    }
}
