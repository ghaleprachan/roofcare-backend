using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roofcare_APIs.Data;
using Roofcare_APIs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private BookingService bookingService;
        public BookingController(RoofCareDbContext roofCareDbContext)
        {
            bookingService = new BookingService(roofCareDbContext);
        }


        [HttpGet]
        public IActionResult Get(int userId, bool isBooked)
        {
            return Ok(bookingService.GetBookings(userId, isBooked));
        }

        [HttpGet]
        [Route("GetBookingHistory")]
        public IActionResult GetBookingHistory(int userId)
        {
            return Ok(bookingService.GetBookingHistory(userId));
        }

        [HttpDelete]
        public IActionResult Delete(int bookingId)
        {
            return Ok(bookingService.DeleteBooking(bookingId));
        }

        [HttpPut]
        public IActionResult Put(int bookingId)
        {
            return Ok(bookingService.UpdateCompletedStatus(bookingId));
        }
    }
}
