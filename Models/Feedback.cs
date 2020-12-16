using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public int FeedbackById { get; set; }
        public int FeedbackToId { get; set; }
        public string FeedbackText { get; set; }
        public double Rating { get; set; }
        public DateTime FeedbackDate { get; set; }
        public virtual User FeedbackBy { get; set; }
        public virtual User FeedbackTo { get; set; }
    }
}
