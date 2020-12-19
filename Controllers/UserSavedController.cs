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
    public class UserSavedController : ControllerBase
    {
        private UserSavedService userSavedService;
        public UserSavedController(RoofCareDbContext roofCareDbContext)
        {
            userSavedService = new UserSavedService(roofCareDbContext);
        }
        [HttpGet]
        public IActionResult Get(int userId)
        {
            return Ok(userSavedService.GetSavedOffers(userId));
        }
        [HttpGet]
        [Route("/GetId")]
        public IActionResult GetId(int userId)
        {
            return Ok(userSavedService.GetId(userId));
        }
        [HttpPost]
        public IActionResult Post(SaveOfferModel offerModel)
        {
            return Ok(userSavedService.SaveOffer(offerModel));
        }

        [HttpDelete]
        public IActionResult Delete(int savedId)
        {
            return Ok(userSavedService.DeleteUserSaved(savedId));
        }
    }
}
