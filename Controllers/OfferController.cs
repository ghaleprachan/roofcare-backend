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

        [Obsolete]
        public OfferController(RoofCareDbContext dbContext, IHostingEnvironment env)
        {
            offerService = new OfferService(dbContext, env);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult Post(AddOfferModel offerModels)
        {
            return Ok(offerService.AddOffer(offerModels));
        }
    }
}
