using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roofcare_APIs.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string ServiceType { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public string CustomerAddress { get; set; }
        public string ProblemDescription { get; set; }
        public string ProblemImage { get; set; }
        public bool VendorAcceptance { get; set; }
        public bool CompletedStatus { get; set; }
        //BILL
       
        public double? ServiceCharge { get; set; }
        public double? TravellingCost { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? TotalCharge { get; set; }
        public bool? CustomerAcceptance { get; set; }
        public bool? PaidStatus { get; set; }
        public DateTime? IssuedDate { get; set; }

        
        public virtual User BookingBy{ get; set; }
        
        public virtual User BookingTo{ get; set; }
    }
}
