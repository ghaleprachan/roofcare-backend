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
    [Route("api/offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private OffersService offersService;
        public OffersController(RoofCareDbContext roofCareDbContext)
        {
            offersService = new OffersService(roofCareDbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(offersService.GetAllOffers());
        }
    }
}
