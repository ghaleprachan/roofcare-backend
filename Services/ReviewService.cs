using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class ReviewService
    {
        private RoofCareDbContext _roofCareDbContext;
        public ReviewService(RoofCareDbContext roofCareDbContext)
        {
            _roofCareDbContext = roofCareDbContext;
        }

        internal object GetUserReview(string userId)
        {
            try
            {
                var userReview = (from u in _roofCareDbContext.Users
                                  select new
                                  {
                                      u.UserId,
                                      u.Username,
                                      Reviews = from r in u.FeedbacksTo
                                                select new
                                                {
                                                    r.FeedbackId,
                                                    r.FeedbackDate,
                                                    r.FeedbackText,
                                                    r.Rating,
                                                    ById = r.FeedbackBy.UserId,
                                                    ByUserName = r.FeedbackBy.Username,
                                                    ByFullName = r.FeedbackBy.FullName,
                                                    ByImage = r.FeedbackBy.UserImage
                                                }
                                  }).Where(un => un.Username == userId).FirstOrDefault();
                return userReview;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object AddUserReview(Feedback reviewModel)
        {
            try
            {
                using (_roofCareDbContext)
                {
                    _roofCareDbContext.Feedbacks.Add(reviewModel);
                    _roofCareDbContext.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
