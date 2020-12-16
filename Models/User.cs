using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string UserType { get; set; }
        public string UserImage { get; set; }
        public string About { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public bool Verified { get; set; }

        public ICollection<Booking> BookingsBy { get; set; }
        public ICollection<Booking> BookingsTo { get; set; }

        public ICollection<SavedOffer> SavedOffers { get; set; }
        public ICollection<UserProfession> UserProfessions { get; set; }
        public ICollection<OfferReport> OfferReports { get; set; }
        public ICollection<Offer> Offers { get; set; }

        public ICollection<Feedback> FeedbacksBy { get; set; }
        public ICollection<Feedback> FeedbacksTo { get; set; }

        public ICollection<Favorite> UserFavsBy { get; set; }
        public ICollection<Favorite> UserFavsTo { get; set; }
    }
}
