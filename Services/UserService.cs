using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Data;
using Roofcare_APIs.Helper;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
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

        public static dynamic UserAuthorizationAsync(UserCredentialModel userCredential)
        {
            try
            {
                using (_roofCareDbContext)
                {
                    var user = (from u in _roofCareDbContext.Users
                                select new
                                {
                                    u.Username,
                                    u.Password,
                                    u.FullName,
                                    u.UserImage,
                                    u.UserType,
                                }).ToList().FirstOrDefault(x => x.Username.Equals(userCredential.Username, StringComparison.OrdinalIgnoreCase)
                                && x.Password.Equals(userCredential.Password));
                    if (user != null)
                    {
                        return Responses.AuthenticationResponse(true, "Log in successful", user.Username, user.FullName, user.UserType, user.UserImage);
                    }
                    else
                    {
                        return Responses.AuthenticationResponse(false, "Invalid username or password.", null, null, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return Responses.AuthenticationResponse(false, ex.Message, null, null, null, null);
            }
        }
    }
}
