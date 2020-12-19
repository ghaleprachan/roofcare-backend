using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roofcare_APIs.Data;
using Roofcare_APIs.Services;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRequestController : ControllerBase
    {
        private BookingRequestService bookingRequest;
        public BookingRequestController(RoofCareDbContext roofCareDbContext)
        {
            bookingRequest = new BookingRequestService(roofCareDbContext);
        }
        [HttpPost]
        public IActionResult Post(BookingRequestModel requestModel)
        {
            return Ok(bookingRequest.AddBookingRequest(requestModel));
        }

        [HttpPut]
        public IActionResult Put(BillModel billModel)
        {
            return Ok(bookingRequest.AcceptBookingRequest(billModel));
        }
    }
}
