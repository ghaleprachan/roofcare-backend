using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class OfferReport
    {
        public int Id { get; set; }
        public int ReportedById { get; set; }
        public int ReportedOfferId { get; set; }
        public string ReportText { get; set; }
        public DateTime ReportedDate { get; set; }
    }
}

