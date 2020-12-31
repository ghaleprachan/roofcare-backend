using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class UpdateProfileService
    {
        private readonly RoofCareDbContext _dbContext;

        public UpdateProfileService(RoofCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object UpdateProfile(UpdateProfileModel model)
        {
            try
            {
                User old_user = _dbContext.Users.Find(model.UserId);
                if (old_user != null)
                {
                    old_user.FullName = model.Name;
                    old_user.Gender = model.Gender;
                    old_user.Address = model.Address;
                    old_user.Contact = model.Contact;
                    old_user.DOB = model.Dob;
                    old_user.About = model.About;
                    _dbContext.Entry(old_user).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return new Response { Success=true, Message = "Details Updated"};
                }
                else
                {
                    return new Response { Success = false, Message = "Update Failed" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = "Update Failed" };
            }
        }
    }
}
