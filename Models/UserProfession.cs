using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class UserProfession
    {
        [Key]
        public int UserProfessionId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("ProfessionId")]
        public int ProfessionId { get; set; }
        public virtual User User { get; set; }
        public virtual Profession Profession { get; set; }
    }
}
