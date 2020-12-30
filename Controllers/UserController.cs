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
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(RoofCareDbContext roofCareDbContext)
        {
            _userService = new UserService(roofCareDbContext);
        }
        [HttpPost]
        [Route("LogInAuthorization")]
        public IActionResult LogInAuthorization([FromBody] UserCredentialModel userCredential)
        {
            return Ok(UserService.UserAuthorizationAsync(userCredential));
        }

        [HttpGet]
        [Route("GetProfileDetails/{id}")]
        public IActionResult GetProfileDetails(string id)
        {
            return Ok(UserService.GetProfileDetails(id));
        }

        [HttpPut]
        public IActionResult Put(int userId, String oldPassword, String newPassword)
        {
            return Ok(_userService.ChangePassword(userId, oldPassword, newPassword));
        }

        [HttpGet]
        public IActionResult Get(int userId)
        {
            return Ok(_userService.GetUserSkills(userId));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_userService.DeleteProfession(id));
        }
    }
}
