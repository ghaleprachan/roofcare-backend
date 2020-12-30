using Microsoft.AspNetCore.Hosting;
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
    public class OfferController : ControllerBase
    {
        private readonly OfferService offerService;

        public OfferController(RoofCareDbContext dbContext)
        {
            offerService = new OfferService(dbContext);
        }

        [HttpPost]
        public IActionResult Post(AddOfferModel offerModels)
        {
            return Ok(offerService.AddOffer(offerModels));
        }
    }
}
