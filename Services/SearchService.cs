using Roofcare_APIs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class SearchService
    {
        private RoofCareDbContext _dbContext;
        public SearchService(RoofCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object SearchItem(string searchItem)
        {
            try
            {
                using (_dbContext)
                {
                    var searchResult = (from prop in _dbContext.UserProfessions
                                        select new
                                        {
                                            prop.Profession.ProfessionId,
                                            prop.Profession.ProfessionName,
                                            prop.User.UserId,
                                            prop.User.Username,
                                            prop.User.FullName,
                                            prop.User.Verified,
                                            prop.User.UserType,
                                            prop.User.UserImage,
                                        }).Where(u => u.ProfessionName.StartsWith(searchItem))
                                        .ToList();

                    return searchResult;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
