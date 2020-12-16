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
        public int UserFavById { get; set; }
        public int UserFavToId { get; set; }
        public DateTime AddedDate { get; set; }
        public virtual User UserFavBy { get; set; }
        public virtual User UserFavTo { get; set; }
    }
}
