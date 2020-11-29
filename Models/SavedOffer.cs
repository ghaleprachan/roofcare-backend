using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class SavedOffer
    {
        public int SavedOfferId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
