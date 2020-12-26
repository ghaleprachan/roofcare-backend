using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class BookingRequestService
    {
        private RoofCareDbContext _dbContext;

        public BookingRequestService(RoofCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object AddBookingRequest(BookingRequestModel requestModel)
        {
            try
            {
                Booking new_request = new Booking
                {
                    BookingById = requestModel.BookingById,
                    BookingToId = requestModel.BookingToId,
                    ServiceType = requestModel.ServiceType,
                    BookingDate = DateTime.Now,
                    ServiceDate = Convert.ToDateTime(requestModel.ServiceDate),
                    CustomerAddress = requestModel.CustomerAddress,
                    ProblemDescription = requestModel.ProblemDescription,
                    VendorAcceptance = false,
                    CompletedStatus = false,
                };
                _dbContext.Bookings.Add(new_request);
                _dbContext.SaveChanges();
                return "{Success: true}";
            }
            catch (Exception ex)
            {
                return "{ Success:  " + ex.Message + "}";
            }
        }

        internal object AcceptBookingRequest(BillModel billModel)
        {
            try
            {
                Booking acc_booking = _dbContext.Bookings.Find(billModel.BookingId);

                if (acc_booking != null)
                {
                    acc_booking.ServiceCharge = billModel.ServiceCharge;
                    acc_booking.TravellingCost = billModel.TravellingCost;
                    acc_booking.DiscountPercentage = billModel.DiscountPercentage;
                    acc_booking.TotalCharge = billModel.TotalCharge;
                    acc_booking.IssuedDate = DateTime.Now;
                    acc_booking.VendorAcceptance = true;
                    _dbContext.Entry(acc_booking).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "{Success: true}";
                }
                else
                {
                    return "{Success: false}";
                }
            }
            catch (Exception ex)
            {
                return "{ Success:  " + ex.Message + "}";
            }
        }
    }
}
