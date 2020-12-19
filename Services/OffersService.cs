using Microsoft.EntityFrameworkCore;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class OffersService
    {
        private RoofCareDbContext _roofCareDbContext;
        public OffersService(RoofCareDbContext roofCareDbContext)
        {
            _roofCareDbContext = roofCareDbContext;
        }

        internal object GetAllOffers()
        {
            try
            {
                var offers = (from offer in _roofCareDbContext.Offers
                              select new
                              {
                                  offer.OfferId,
                                  offer.ValidDate,
                                  offer.OfferImage,
                                  offer.PostedDate,
                                  offer.OfferDescription,
                                  AddedByName = offer.User.FullName,
                                  AddedByUsername = offer.User.Username,
                                  AddedByContact = offer.User.Contact,
                                  AddedByImage = offer.User.UserImage
                              }).ToList();
                return offers;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object DeleteOffer(int offerId)
        {
            try
            {
                using (_roofCareDbContext)
                {
                    Offer oldOffer = _roofCareDbContext.Offers.Find(offerId);
                    if (oldOffer != null)
                    {
                        _roofCareDbContext.Remove(oldOffer);
                        _roofCareDbContext.SaveChanges();
                        return "Delete Successful";
                    }
                    else
                    {
                        return "Offer doesn't exists!";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal object GetUserOffers(string username)
        {
            try
            {
                var offers = (from offer in _roofCareDbContext.Offers
                              select new
                              {
                                  offer.OfferId,
                                  offer.ValidDate,
                                  offer.OfferImage,
                                  offer.PostedDate,
                                  offer.OfferDescription,
                                  AddedByName = offer.User.FullName,
                                  AddedByUsername = offer.User.Username,
                                  AddedByContact = offer.User.Contact,
                                  AddedByImage = offer.User.UserImage
                              }).Where(u => u.AddedByUsername == username).ToList();
                return offers;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
