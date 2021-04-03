using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
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

        internal object GetRatings(int id)
        {
            try
            {
                int fivestar = (from feedback in _roofCareDbContext.Feedbacks
                                select new
                                {
                                    feedback.Rating,
                                    feedback.FeedbackToId,
                                }).Where(user => user.FeedbackToId.Equals(id) && Math.Round(user.Rating, 1).Equals(5)).ToList().Count();

                int fourstart = (from feedback in _roofCareDbContext.Feedbacks
                                 select new
                                 {
                                     feedback.Rating,
                                     feedback.FeedbackToId,
                                 }).Where(user => user.FeedbackToId.Equals(id) && Math.Round(user.Rating, 0).Equals(4)).ToList().Count();

                int threestar = (from feedback in _roofCareDbContext.Feedbacks
                                 select new
                                 {
                                     feedback.Rating,
                                     feedback.FeedbackToId,
                                 }).Where(user => user.FeedbackToId.Equals(id) && Math.Round(user.Rating, 0).Equals(3)).ToList().Count();

                int twostar = (from feedback in _roofCareDbContext.Feedbacks
                               select new
                               {
                                   feedback.Rating,
                                   feedback.FeedbackToId,
                               }).Where(user => user.FeedbackToId.Equals(id) && Math.Round(user.Rating, 0).Equals(2)).ToList().Count();

                int onestar = (from feedback in _roofCareDbContext.Feedbacks
                               select new
                               {
                                   feedback.Rating,
                                   feedback.FeedbackToId,
                               }).Where(user => user.FeedbackToId.Equals(id) && Math.Round(user.Rating, 0).Equals(1)).ToList().Count();

                double rating = (double)(5 * fivestar + 4 * fourstart + 3 * threestar + 2 * twostar + 1 * onestar) / (onestar + twostar + threestar + fourstart + fivestar);

                rating = Math.Round(rating, 1);
                
                return new Response { Success = true, Message = rating.ToString() };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = ex.Message };
            }
        }

        internal object AddUserReview(AddFeedbackModel reviewModel)
        {
            try
            {
                using (_roofCareDbContext)
                {
                    Feedback feedback = new Feedback
                    {
                        FeedbackById = reviewModel.FeedbackById,
                        FeedbackToId = reviewModel.FeedbackToId,
                        Rating = reviewModel.Rating,
                        FeedbackText = reviewModel.FeedbackText,
                        FeedbackDate = DateTime.Now
                    };

                    _roofCareDbContext.Feedbacks.Add(feedback);
                    _roofCareDbContext.SaveChanges();
                    return "{ Success: true}";
                }
            }
            catch
            {
                return "Success:false";
            }
        }
    }
}
