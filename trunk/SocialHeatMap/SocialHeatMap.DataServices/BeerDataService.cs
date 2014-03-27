using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices
{
    public static class BeerDataService
    {
        public static List<KeyValuePair<int,string>> GetAllBrands()
        {
            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                List<Brand> dbResults = (from a in context.Brands select a).ToList();

                foreach (Brand item in dbResults)
                    result.Add(new KeyValuePair<int,string>(item.BrandID, item.Name));
            }

            return result;
        }
    }
}
