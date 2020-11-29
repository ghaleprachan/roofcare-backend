using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int FeedbackBy { get; set; }
        public int FeedbaclTo { get; set; }
        public string FeedbackText { get; set; }
        public double Rating { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
