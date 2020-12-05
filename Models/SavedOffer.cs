﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class SavedOffer
    {
        [Key]
        public int SavedOfferId { get; set; }
        public DateTime SaveDate { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
    }
}
