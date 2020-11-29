using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        public String ProfessionName { get; set; }
        public ICollection<UserProfession> UserProfessions { get; set; }
    }
}
