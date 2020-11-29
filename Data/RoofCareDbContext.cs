using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Data
{
    public class RoofCareDbContext : DbContext
    {
        public RoofCareDbContext(DbContextOptions<RoofCareDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferReport> OfferReports { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<SavedOffer> SavedOffers { get; set; }
        public DbSet<UserProfession> UserProfessions { get; set; }
    }
}
