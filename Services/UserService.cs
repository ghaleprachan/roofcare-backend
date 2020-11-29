using Roofcare_APIs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class UserService
    {
        private static RoofCareDbContext _roofCareDbContext;
        public UserService(RoofCareDbContext roofCareDbContext)
        {
            _roofCareDbContext = roofCareDbContext;
        }

        public static dynamic getUsers()
        {
            return _roofCareDbContext.Users;
        } 
    }
}
