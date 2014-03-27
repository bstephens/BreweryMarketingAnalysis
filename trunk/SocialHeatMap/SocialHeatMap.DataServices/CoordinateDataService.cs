using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices
{
    public class CoordinateDataService
    {
        /*public static List<TBL_COORDS> GetAllCoordinates()
        {
            List<TBL_COORDS> result = new List<TBL_COORDS>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.TBL_COORDS
                          select a).ToList();
            }

            return result;
        }*/

        public static bool SaveTweet(int brandId, string information, double latitude, double longitude)
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                SocialMediaInfo tweet = new SocialMediaInfo();
                tweet.BrandID = brandId;
                tweet.Information = information;
                tweet.Latitude = latitude;
                tweet.Longitude = longitude;
                tweet.SearchDate = DateTime.Now;
                context.SocialMediaInfoes.AddObject(tweet);
                context.SaveChanges();
            }
            return true;
        }
    }
}
