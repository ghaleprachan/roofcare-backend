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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(RoofCareDbContext roofCareDbContext)
        {
            _userService = new UserService(roofCareDbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UserService.getUsers());
        }
    }
}
