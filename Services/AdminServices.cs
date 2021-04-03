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
    public class AdminServices
    {
        private readonly RoofCareDbContext _dbContext;
        public AdminServices(RoofCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object Login(AdminLogin loginRequest)
        {
            var old_admin = _dbContext.Admins.Where(a => a.Username == loginRequest.Username && a.Password == loginRequest.Password).FirstOrDefault();
            if (old_admin != null)
            {
                return old_admin;
            }
            else
            {
                return "Admin don't exists!";
            }
        }

        internal object Register(AdminRegister registerRequest)
        {
            var old_admin = _dbContext.Admins.Where(a => a.Username == registerRequest.Username).FirstOrDefault();
            if (old_admin == null)
            {
                Admin new_admin = new()
                {
                    FullName = registerRequest.FullName,
                    Username = registerRequest.Username,
                    Password = registerRequest.Password
                };
                _dbContext.Admins.Add(new_admin);
                _dbContext.SaveChanges();
                return new_admin;
            }
            else
            {
                return "User with username already exists!";
            }
        }

        internal object GetProfessions()
        {
            var professions = _dbContext.Professions.Select(p => new
            {
                p.ProfessionId,
                p.ProfessionName
            }).ToList();

            AdminResponse response = new()
            {
                Success = true,
                Professions = professions
            };
            return response;

            throw new NotImplementedException();
        }

        internal object DeleteProefession(int id)
        {
            Profession profession = _dbContext.Professions.Find(id);
            if (profession != null)
            {
                _dbContext.Professions.Remove(profession);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }

        internal object UpdateProfession(int id, string professionName)
        {
            var old_profession = _dbContext.Professions.Where(p => p.ProfessionId == id).FirstOrDefault();
            old_profession.ProfessionName = professionName;
            _dbContext.Entry(old_profession).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        internal object AddProfession(string professionName)
        {
            var old_profession = _dbContext.Professions.Where(p => p.ProfessionName == professionName).FirstOrDefault();
            if (old_profession == null)
            {
                Profession new_profession = new()
                {
                    ProfessionName = professionName
                };
                _dbContext.Professions.Add(new_profession);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class AdminResponse
    {
        public bool Success { get; set; }
        public dynamic Professions { get; set; }
    }
}
