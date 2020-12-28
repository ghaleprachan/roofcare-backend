using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class RegisterService
    {
        private RoofCareDbContext _dbContext;
        [Obsolete]
        private IHostingEnvironment _env;

        [Obsolete]
        public RegisterService(RoofCareDbContext dbContext, IHostingEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
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

                    var services = _dbContext.Professions.ToList();
                    return HelperResponse.HelperRegister(true, new_user.UserId, services);
                }
                else
                {
                    return HelperResponse.HelperRegister(false, -1, null);
                }
            }
            catch (Exception ex)
            {
                return "{Success:" + ex.Message + "}";
            }
        }

        [Obsolete]
        internal object AddProfileImage(ProfileImageModel model)
        {
            try
            {
                User user = _dbContext.Users.Find(model.UserId);
                if (user != null)
                {
                    user.UserImage = ParseImage(model.userImage);
                    _dbContext.Entry(user).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return "{success:true, image:"+user.UserImage+"}";
                }
                else
                {
                    return "{success:false}";
                }
            }
            catch (Exception ex)
            {
                return "{success:" + ex.Message + "}";
            }
        }

        [Obsolete]
        private string ParseImage(String bitmapString)
        {
            try
            {
                string folderLocation = "ProfileImg/";
                string imageName = ((RandomString(10) + DateTime.Now) + ".jpg").Replace(":", String.Empty);

                byte[] img = LoadImage(bitmapString);

                string filePath = System.IO.Path.Combine(_env.WebRootPath + folderLocation +
                    Path.GetFileName(imageName));

                File.WriteAllBytes(filePath, img);

                string finalLocation = "ProfileImages/";
                return (finalLocation + imageName);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public byte[] LoadImage(string bitmapString)
        {
            byte[] imageBytes = Convert.FromBase64String(bitmapString);
            return imageBytes;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        internal object AddProfession(int userId, int professionId)
        {
            try
            {
                UserProfession userProfession = _dbContext.UserProfessions.Where(u => u.UserId == userId && u.ProfessionId == professionId).FirstOrDefault();
                if (userProfession == null)
                {
                    UserProfession new_profession = new UserProfession
                    {
                        UserId = userId,
                        ProfessionId = professionId
                    };
                    _dbContext.UserProfessions.Add(new_profession);
                    _dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            catch (Exception ex)
            {
                return "{success:" + ex.Message + "}";
            }
        }
    }
}
