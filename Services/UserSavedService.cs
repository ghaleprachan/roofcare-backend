using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class UserSavedService
    {
        private RoofCareDbContext _dbContext;
        public UserSavedService(RoofCareDbContext roofCareDbContext)
        {
            _dbContext = roofCareDbContext;
        }
        internal object GetSavedOffers(int userId)
        {
            try
            {
                var savedOffers = (from u in _dbContext.Users
                                   select new
                                   {
                                       u.UserId,
                                       SavedOffer = (from o in u.SavedOffers
                                                     select new
                                                     {
                                                         o.SavedOfferId,
                                                         o.OfferId,
                                                         o.Offer.OfferDescription,
                                                         o.Offer.OfferImage,
                                                         o.Offer.PostedDate,
                                                         o.Offer.ValidDate,
                                                         OfferUserId = o.Offer.User.UserId,
                                                         OfferUsername = o.Offer.User.Username,
                                                         OfferFullName = o.Offer.User.FullName,
                                                         OfferPhoneNum = o.Offer.User.Contact,
                                                         OfferUserImage = o.Offer.User.UserImage,
                                                     }).ToList()

                                   }).Where(us => us.UserId == userId).FirstOrDefault();
                return savedOffers;

            }
            catch (Exception ex)
            {
                return "{Success: " + ex.Message + "}";
            }
        }

        internal object DeleteUserSaved(int savedId)
        {
            try
            {
                SavedOffer old_saved = _dbContext.SavedOffers.Find(savedId);
                if (old_saved != null)
                {
                    _dbContext.Remove(old_saved);
                    _dbContext.SaveChanges();
                    return "Unsaved";
                }
                else
                {
                    return "Offer Save not found";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object GetId(int userId)
        {
            try
            {
                var savedIds = (from u in _dbContext.Users
                                select new
                                {
                                    u.UserId,
                                    Saveds = (from s in u.SavedOffers
                                              select new
                                              {
                                                  s.SavedOfferId,
                                                  s.OfferId
                                              }).ToList()
                                }).Where(ui => ui.UserId == userId).FirstOrDefault();
                return savedIds;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object SaveOffer(SaveOfferModel offerModel)
        {
            try
            {
                using (_dbContext)
                {
                    SavedOffer savedOffer = new SavedOffer
                    {
                        UserId = offerModel.UserId,
                        OfferId = offerModel.OfferId,
                        SaveDate = DateTime.Now
                    };
                    _dbContext.SavedOffers.Add(savedOffer);
                    _dbContext.SaveChanges();
                    return "{Success: true}";
                }
            }
            catch (Exception ex)
            {
                return "{Success: " + ex.Message + "}";
            }
        }
    }
}
