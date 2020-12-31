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
    public class UpdateProfileController : ControllerBase
    {
        private readonly UpdateProfileService updateProfile;
        public UpdateProfileController(RoofCareDbContext dbContext)
        {
            updateProfile = new UpdateProfileService(dbContext);
        }

        [HttpPut]
        public IActionResult Put(UpdateProfileModel model)
        {
            return Ok(updateProfile.UpdateProfile(model));
        }
    }
}
