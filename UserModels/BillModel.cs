using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class BillModel
    {
        public int BookingId { get; set; }
        public double ServiceCharge { get; set; }
        public double TravellingCost { get; set; }
        public double  DiscountPercentage { get; set; }
        public double TotalCharge { get; set; }
    }
}
