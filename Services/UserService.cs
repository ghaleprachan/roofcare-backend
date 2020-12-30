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
                                    u.UserId,
                                    u.Username,
                                    u.Password,
                                    u.FullName,
                                    u.UserImage,
                                    u.UserType,
                                }).ToList().FirstOrDefault(x => x.Username.Equals(userCredential.Username, StringComparison.OrdinalIgnoreCase)
                                && x.Password.Equals(userCredential.Password));
                    if (user != null)
                    {
                        return Responses.AuthenticationResponse(true, user.UserId, "Log in successful", user.Username, user.FullName, user.UserType, user.UserImage);
                    }
                    else
                    {
                        return Responses.AuthenticationResponse(false, 0, "Invalid username or password.", null, null, null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                return Responses.AuthenticationResponse(false, 0, ex.Message, null, null, null, null);
            }
        }

        internal object DeleteProfession(int id)
        {
            UserProfession userProfession = _roofCareDbContext.UserProfessions.Find(id);
            if (userProfession != null)
            {
                _roofCareDbContext.UserProfessions.Remove(userProfession);
                _roofCareDbContext.SaveChanges();
                return "Success";
            }
            else
            {
                return "Already Deleted";
            }
        }

        internal object GetUserSkills(int userId)
        {
            var userSkills = (from s in _roofCareDbContext.UserProfessions
                              select new
                              {
                                  s.UserProfessionId,
                                  s.UserId,
                                  s.ProfessionId,
                                  s.Profession.ProfessionName
                              }).Where(u => u.UserId == userId);
            return userSkills;
        }

        internal object ChangePassword(int userId, string oldPassword, string newPassword)
        {
            User user = _roofCareDbContext.Users.Find(userId);
            if (user != null)
            {
                if (user.Password.Equals(oldPassword))
                {
                    user.Password = newPassword;
                    _roofCareDbContext.Entry(user).State = EntityState.Modified;
                    _roofCareDbContext.SaveChanges();
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            else
            {
                return "Invalid user token provided!";
            }
        }

        internal static object GetProfileDetails(string id)
        {
            try
            {
                var user = (from u in _roofCareDbContext.Users
                            select new
                            {
                                u.Username,
                                u.FullName,
                                u.Gender,
                                u.DOB,
                                u.UserType,
                                u.UserImage,
                                u.About,
                                u.Verified,
                                u.Address,
                                u.Contact,
                                Professions = (from p in u.UserProfessions
                                               select new
                                               {
                                                   p.Profession.ProfessionId,
                                                   p.Profession.ProfessionName
                                               }).ToList()
                            })
                            .ToList()
                            .FirstOrDefault(x => x.Username.Equals(id, StringComparison.OrdinalIgnoreCase));
                return user;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
