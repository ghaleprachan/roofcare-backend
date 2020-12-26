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
        public RegisterController(RoofCareDbContext dbContext)
        {
            register = new RegisterService(dbContext);
        }

        [HttpPost]
        public IActionResult Post(RegisterModel user)
        {
            return Ok(register.RegisterNewUser(user));
        }
    }
}
