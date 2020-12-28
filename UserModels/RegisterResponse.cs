using Roofcare_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.UserModels
{
    public class RegisterResponse
    {
        public bool Success { get; set; }
        public int UserId { get; set; }
        public dynamic Professions { get; set; }
    }

    public class HelperResponse
    {
        public static RegisterResponse HelperRegister(bool success,int userId, dynamic professions)
        {
            return new RegisterResponse
            {
                Success = success,
                UserId = userId,
                Professions = professions
            };
        }
    }
}
