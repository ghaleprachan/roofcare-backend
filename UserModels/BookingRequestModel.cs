using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class BookingRequestModel
    {
        public int BookingById { get; set; }
        public int BookingToId { get; set; }
        public string ServiceType { get; set; }
        public string ServiceDate { get; set; }
        public string CustomerAddress { get; set; }
        public string ProblemDescription { get; set; }
    }
}
