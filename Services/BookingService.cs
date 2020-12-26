using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
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
        { // if is booked is true than shows bookings
            // if the booked in false than shows booking requests
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
                                                   b.VendorAcceptance,
                                                   b.CompletedStatus
                                               }).OrderByDescending(q => q.BookingDate).Where(ib => ib.BookingById == userId && ib.VendorAcceptance == isBooked && ib.CompletedStatus == false),
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
                                                    b.VendorAcceptance,
                                                    b.CompletedStatus
                                                }).OrderByDescending(q => q.BookingDate).Where(ib => ib.BookingToId == userId && ib.VendorAcceptance == isBooked && ib.CompletedStatus == false)
                                }).Where(us => us.UserId == userId).FirstOrDefault();
                return bookings;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object GetBookingHistory(int userId)
        {
            try
            {
                var bookings = (from b in _dbContext.Bookings
                                select new
                                {

                                    b.BookingId,
                                    BookingById = b.BookingBy.UserId,
                                    BookingByName = b.BookingBy.FullName,
                                    BookingByUsername = b.BookingBy.Username,
                                    BookingByImage = b.BookingBy.UserImage,
                                    BookingToId = b.BookingTo.UserId,
                                    BookingToUsername = b.BookingTo.Username,
                                    BookingToFullName = b.BookingTo.FullName,
                                    BookingToUserImage = b.BookingTo.UserImage,
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
                                    b.VendorAcceptance,
                                    b.CompletedStatus
                                }).OrderByDescending(q => q.BookingDate)
                                               .Where(ib => ib.CompletedStatus == true && (ib.BookingById == userId || ib.BookingToId == userId));
                return bookings;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object UpdateCompletedStatus(int bookingId)
        {
            try
            {
                Booking acc_booking = _dbContext.Bookings.Find(bookingId);

                if (acc_booking != null)
                {
                    acc_booking.CompletedStatus = true;
                    _dbContext.Entry(acc_booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                return "{ Success:  " + ex.Message + "}";
            }
        }

        internal object DeleteBooking(int bookingId)
        {
            try
            {
                var old_booking = _dbContext.Bookings.Find(bookingId);
                if (old_booking != null)
                {
                    _dbContext.Bookings.Remove(old_booking);
                    _dbContext.SaveChanges();
                    return "{Success : Deleted Successfully}";
                }
                else
                {
                    return "{Success : Alredy Deleted}";
                }
            }
            catch (Exception ex)
            {
                return "{Success: " + ex.Message + "}";
            }
        }
    }
}
