using Microsoft.AspNetCore.Mvc;
using Roofcare_APIs.Data;
using Roofcare_APIs.Services;
using Roofcare_APIs.UserModels;

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

        [HttpPost]
        [Route("AddProfession/{professionName}")]
        public IActionResult AddProfession(string professionName)
        {
            return Ok(adminServices.AddProfession(professionName));
        }
        [HttpGet]
        [Route("GetProfessions")]
        public IActionResult GetProfessions()
        {
            return Ok(adminServices.GetProfessions());
        }
        [HttpPut]
        [Route("UpdateProfession/{id}/{professionName}")]
        public IActionResult UpdateProfession(int id, string professionName)
        {
            return Ok(adminServices.UpdateProfession(id, professionName));
        }

        [HttpDelete]
        [Route("UpdateProfession/{id}")]
        public IActionResult DeleteProfession(int id)
        {
            return Ok(adminServices.DeleteProefession(id));
        }
    }
}
