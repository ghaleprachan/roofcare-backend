using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class AddFeedbackModel
    {
        public int FeedbackById { get; set; }
        public int FeedbackToId { get; set; }
        public string FeedbackText { get; set; }
        public double Rating { get; set; }
    }
}
