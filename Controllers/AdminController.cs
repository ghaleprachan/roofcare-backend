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
    public class AdminController : ControllerBase
    {
        private readonly AdminServices adminServices;
        public AdminController(RoofCareDbContext dbContext)
        {
            adminServices = new AdminServices(dbContext);
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AdminLogin loginRequest)
        {
            return Ok(adminServices.Login(loginRequest));
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register([FromBody] AdminRegister registerRequest)
        {
            return Ok(adminServices.Register(registerRequest));
        }

        [HttpGet]
        [Route("AddProfession/{professionName}")]
        public IActionResult AddProfession(string professionName)
        {
            return Ok(adminServices.AddProfession(professionName));
        }
        [HttpPut]
        [Route("UpdateProfession/{id}/{professionName}")]
        public IActionResult UpdateProfession(int id, string professionName)
        {
            return Ok(adminServices.UpdateProfession(id, professionName));
        }
    }
}
