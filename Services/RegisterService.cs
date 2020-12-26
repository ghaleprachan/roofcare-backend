using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class RegisterService
    {
        private RoofCareDbContext _dbContext;
        public RegisterService(RoofCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object RegisterNewUser(RegisterModel user)
        {
            try
            {
                User existing_user = _dbContext.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existing_user == null)
                {
                    User new_user = new User()
                    {
                        Username = user.Username,
                        Password = user.Password,
                        FullName = user.FullName,
                        Gender = user.Gender,
                        DOB = user.DOB,
                        UserType = user.UserType,
                        About = user.About,
                        Contact = user.Contact,
                        Address = user.Address,
                        Verified = false
                    };
                    _dbContext.Users.Add(new_user);
                    _dbContext.SaveChanges();
                    return "{Success:true, UserId:" + new_user.UserId + "}";
                }
                else
                {
                    return "{Success:false}";
                }
            }
            catch (Exception ex)
            {
                return "{Success:" + ex.Message + "}";
                ;
            }
        }
    }
}
