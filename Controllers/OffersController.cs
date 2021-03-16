using Microsoft.AspNetCore.Mvc;
using Roofcare_APIs.Data;
using Roofcare_APIs.Services;

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
        [HttpGet]
        [Route("GetUserOffers")]
        public IActionResult GetUserOffers(string username)
        {
            return Ok(offersService.GetUserOffers(username));
        }

        [HttpDelete]
        public IActionResult Delete(int offerId)
        {
            return Ok(offersService.DeleteOffer(offerId));
        }
    }
}
