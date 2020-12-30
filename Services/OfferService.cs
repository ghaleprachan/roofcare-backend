using Microsoft.AspNetCore.Hosting;
using Roofcare_APIs.Data;
using Roofcare_APIs.Models;
using Roofcare_APIs.UserModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Roofcare_APIs.Services
{
    public class OfferService
    {
        private const string baseLocation = "MyUploads/";
        private readonly RoofCareDbContext _dbContext;
        public OfferService(RoofCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        internal object AddOffer(AddOfferModel offerModel)
        {
            try
            {
                Offer new_offer = new Offer
                {
                    UserId = offerModel.UserId,
                    OfferDescription = offerModel.OfferDescription,
                    OfferImage = ParseImage(offerModel.OfferImage),
                    ValidDate = offerModel.ValidDate,
                    PostedDate = DateTime.Now
                };
                _dbContext.Offers.Add(new_offer);
                _dbContext.SaveChanges();
                return "{Success: true}";

            }
            catch (Exception ex)
            {
                return "{Success: " + ex.Message + "}";
            }
        }

        private string ParseImage(String bitmapString)
        {
            try
            {
                string folderLocation = baseLocation;
                string imageName = ((RandomString(10) + DateTime.Now) + ".jpg").Replace(":", String.Empty);

                byte[] img = LoadImage(bitmapString);

                string filePath = Path.Combine(folderLocation +
                    Path.GetFileName(imageName));

                File.WriteAllBytes(filePath, img);
                return filePath;
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
    }
}
