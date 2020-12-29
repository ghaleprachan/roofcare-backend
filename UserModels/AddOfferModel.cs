using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class AddOfferModel
    {
        public int UserId { get; set; }
        public String OfferDescription { get; set; }
        public DateTime ValidDate { get; set; }
        public String OfferImage { get; set; }
    }
}
