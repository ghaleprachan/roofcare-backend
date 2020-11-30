using System;
using System.Collections.Generic;
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
        [ForeignKey("UserId")]
        public ICollection<Booking> Bookings { get; set; }
        [ForeignKey("UserId")]
        public ICollection<SavedOffer> SavedOffers { get; set; }
        [ForeignKey("UserId")]
        public ICollection<UserProfession> UserProfessions { get; set; }
        [ForeignKey("UserId")]
        public ICollection<OfferReport> OfferReports { get; set; }
        [ForeignKey("UserId")]
        public ICollection<Offer> Offers { get; set; }
        [ForeignKey("UserId")]
        public ICollection<Feedback> Feedbacks { get; set; }
        [ForeignKey("UserId")]
        public ICollection<Favorite> Favorites { get; set; }
    }
}
