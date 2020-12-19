using Roofcare_APIs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class BookingService
    {
        private RoofCareDbContext _dbContext;
        public BookingService(RoofCareDbContext roofCareDbContext)
        {
            _dbContext = roofCareDbContext;
        }

        internal object GetBookings(int userId, bool isBooked)
        {
            try
            {
                var bookings = (from u in _dbContext.Users
                                select new
                                {
                                    u.UserId,
                                    u.Username,
                                    u.UserImage,
                                    u.FullName,
                                    IBooked = (from b in u.BookingsBy
                                               select new
                                               {
                                                   b.BookingId,
                                                   b.BookingById,
                                                   b.BookingTo.UserId,
                                                   b.BookingTo.Username,
                                                   b.BookingTo.FullName,
                                                   b.BookingTo.UserImage,
                                                   b.ServiceType,
                                                   b.BookingDate,
                                                   b.ServiceDate,
                                                   b.CustomerAddress,
                                                   b.ProblemDescription,
                                                   b.ServiceCharge,
                                                   b.TravellingCost,
                                                   b.DiscountPercentage,
                                                   b.TotalCharge,
                                                   b.IssuedDate,
                                                   b.VendorAcceptance
                                               }).Where(ib => ib.BookingById == userId && ib.VendorAcceptance == isBooked).ToList(),
                                    ImBooked = (from b in u.BookingsTo
                                                select new
                                                {
                                                    b.BookingId,
                                                    b.BookingToId,
                                                    b.BookingBy.UserId,
                                                    b.BookingBy.Username,
                                                    b.BookingBy.FullName,
                                                    b.BookingBy.UserImage,
                                                    b.ServiceType,
                                                    b.BookingDate,
                                                    b.ServiceDate,
                                                    b.CustomerAddress,
                                                    b.ProblemDescription,
                                                    b.ServiceCharge,
                                                    b.TravellingCost,
                                                    b.DiscountPercentage,
                                                    b.TotalCharge,
                                                    b.IssuedDate,
                                                    b.VendorAcceptance
                                                }).Where(ib => ib.BookingToId == userId && ib.VendorAcceptance == isBooked).ToList()
                                }).Where(us => us.UserId == userId).FirstOrDefault();
                return bookings;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
