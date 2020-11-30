using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int VendorId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int CustomerId { get; set; }
        [Required]
        public string ServiceType { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public string CustomerAddress { get; set; }
        public string ProblemDescription { get; set; }
        public string ProblemImage { get; set; }
        [Required]
        public bool VendorAcceptance { get; set; }
        [Required]
        public bool CompletedStatus { get; set; }
        //BILL
        public double ServiceCharge { get; set; }
        public double TravellingCost { get; set; }
        public double DiscountPercentage { get; set; }
        public double TotalCharge { get; set; }
        public bool CustomerAcceptance { get; set; }
        public bool PaidStatus { get; set; }
        public DateTime IssuedDate { get; set; }
        [NotMapped]
        public virtual User BookedBy { get; set; }
        [NotMapped]
        public virtual User BookedTo { get; set; }
    }
}
