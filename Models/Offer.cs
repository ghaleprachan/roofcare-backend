using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime ValidDate { get; set; }
        public string OfferDescription { get; set; }
        public string OfferImage { get; set; }
        public int OfferBy { get; set; }
        public ICollection<OfferReport> OfferReports { get; set; }
        public ICollection<SavedOffer> SavedOffers { get; set; }
    }
}
