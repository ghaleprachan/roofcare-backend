﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
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
    public class ReviewController : ControllerBase
    {
        private ReviewService _reviewService;
        public ReviewController(RoofCareDbContext roofCareDbContext)
        {
            _reviewService = new ReviewService(roofCareDbContext);
        }
        [HttpGet]
        public IActionResult Get(string userId)
        {
            return Ok(_reviewService.GetUserReview(userId));
        }

        [HttpPost]
        public IActionResult Post(AddFeedbackModel reviewModel)
        {
            return Ok(_reviewService.AddUserReview(reviewModel));
        }

        [HttpGet]
        [Route("GetRatings")]
        public IActionResult GetRatings(int userId)
        {
            return Ok(_reviewService.GetRatings(userId));
        }
    }
}
