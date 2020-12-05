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
    public class UserReviewController : ControllerBase
    {
        private ReviewService _reviewService;
        public UserReviewController(RoofCareDbContext roofCareDbContext)
        {
            _reviewService = new ReviewService(roofCareDbContext);
        }
        [HttpGet]
        public IActionResult Get(string userId)
        {
            return Ok(_reviewService.GetUserReview(userId));
        }
    }
}
