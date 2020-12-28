using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class RegisterController : ControllerBase
    {
        private RegisterService register;
        [Obsolete]
        public RegisterController(RoofCareDbContext dbContext, IHostingEnvironment env)
        {
            register = new RegisterService(dbContext, env);
        }

        [HttpPost]
        public IActionResult Post(RegisterModel user)
        {
            return Ok(register.RegisterNewUser(user));
        }
        [HttpPost]
        [Route("AddProfession")]
        public IActionResult AddProfession(int userId, int professionId)
        {
            return Ok(register.AddProfession(userId, professionId));
        }

        [HttpPost]
        [Route("AddProfileImage")]
        [Obsolete]
        public IActionResult AddProfileImage(ProfileImageModel model)
        {
            return Ok(register.AddProfileImage(model));
        }
    }
}
