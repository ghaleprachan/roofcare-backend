using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Favorite
    {
        public int FavoriteId { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
