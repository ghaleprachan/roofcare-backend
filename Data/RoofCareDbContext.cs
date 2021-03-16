using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Models;

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
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.FeedbackBy) //This is from feedback class
                .WithMany(u => u.FeedbacksBy) // This is from user class
                .IsRequired()
                .HasForeignKey(f => f.FeedbackById) // This is from feedback class
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.FeedbackTo) //This is from feedback class
                .WithMany(u => u.FeedbacksTo) // This is from user class
                .IsRequired()
                .HasForeignKey(f => f.FeedbackToId) // This is from feedback class
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BookingBy)
                .WithMany(u => u.BookingsBy)
                .IsRequired()
                .HasForeignKey(b => b.BookingById)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.BookingTo)
                .WithMany(u => u.BookingsTo)
                .IsRequired()
                .HasForeignKey(b => b.BookingToId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.UserFavBy)
                .WithMany(u => u.UserFavsBy)
                .IsRequired()
                .HasForeignKey(f => f.UserFavById)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.UserFavTo)
                .WithMany(u => u.UserFavsTo)
                .IsRequired()
                .HasForeignKey(f => f.UserFavToId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<OfferReport>()
                .HasOne(o => o.User)
                .WithMany(u => u.OfferReports)
                .IsRequired()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<OfferReport>()
                .HasOne(o => o.Offer)
                .WithMany(u => u.OfferReports)
                .IsRequired()
                .HasForeignKey(o => o.OfferId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<SavedOffer>()
                .HasOne(s => s.User)
                .WithMany(u => u.SavedOffers)
                .IsRequired()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<SavedOffer>()
                .HasOne(s => s.Offer)
                .WithMany(o => o.SavedOffers)
                .IsRequired()
                .HasForeignKey(s => s.OfferId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<UserProfession>()
                .HasOne(up => up.User)
                .WithMany(o => o.UserProfessions)
                .IsRequired()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<UserProfession>()
               .HasOne(up => up.Profession)
               .WithMany(p => p.UserProfessions)
               .IsRequired()
               .HasForeignKey(s => s.ProfessionId)
               .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
