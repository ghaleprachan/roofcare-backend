using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class OfferReport
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }
        public string ReportText { get; set; }
        public DateTime ReportedDate { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
    }
}

