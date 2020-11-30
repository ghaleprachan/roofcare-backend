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
        [ForeignKey("UserId")]
        public int FeedbackBy { get; set; }
        [ForeignKey("UserId")]
        public int FeedbaclTo { get; set; }
        public string FeedbackText { get; set; }
        public double Rating { get; set; }
        public DateTime FeedbackDate { get; set; }
        [NotMapped]
        public virtual User UserBy { get; set; }
        [NotMapped]
        public virtual User UserTo { get; set; }
    }
}
