using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        [ForeignKey("UserId")]
        public int CustomerId { get; set; }
        [ForeignKey("UserId")]
        public int VendorId { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [NotMapped]
        public virtual User UserFavBy { get; set; }
        [NotMapped]
        public virtual User UserFabTo { get; set; }
    }
}
