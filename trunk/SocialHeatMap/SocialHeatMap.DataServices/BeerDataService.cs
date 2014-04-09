using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialHeatMap.DataServices.DataEntities;

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

        public static List<KeyValuePair<int, string>> GetAllTypes()
        {
            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                List<Type> dbResults = (from a in context.Types select a).ToList();

                foreach (Type item in dbResults)
                    result.Add(new KeyValuePair<int, string>(item.TypeID, item.Name));
            }

            return result;
        }

        public static List<KeyValuePair<int, string>> GetAllManufacturers()
        {
            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                List<Manufacturer> dbResults = (from a in context.Manufacturers select a).ToList();

                foreach (Manufacturer item in dbResults)
                    result.Add(new KeyValuePair<int, string>(item.MfrID, item.Name));
            }

            return result;
        }



        public static List<SearchResultEntity> GetSearchResults(FilterEntity filters)
        {
            List<SearchResultEntity> results = new List<SearchResultEntity>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                var dbQuery = (from a in context.SocialMediaInfoes.Include("Brand")
                                                                  .Include("Brand.Manufacturer")
                                                                  .Include("Brand.Manufacturer.AnnualSales")
                               select a);

                if (filters.MaxABV.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Alcohol <= filters.MaxABV.Value);

                if (filters.MaxBarrels.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Manufacturer.Capacity <= filters.MaxBarrels.Value);

                if (filters.MaxCalories.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Calories <= filters.MaxCalories.Value);

                if (filters.MaxSales.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Manufacturer.AnnualSales.FirstOrDefault(y => y.Sales > filters.MaxSales.Value) == null);

                if (filters.MinABV.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Alcohol >= filters.MinABV.Value);

                if (filters.MinBarrels.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Manufacturer.Capacity >= filters.MinBarrels.Value);

                if (filters.MinCalories.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Calories >= filters.MinCalories.Value);

                if (filters.MinSales.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.Manufacturer.AnnualSales.FirstOrDefault(y => y.Sales < filters.MinSales.Value) == null);

                if (filters.SelectedBrandId.HasValue)
                    dbQuery = dbQuery.Where(x => x.BrandID == filters.SelectedBrandId.Value);

                if (filters.SelectedManufacturerId.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.MfrID == filters.SelectedManufacturerId.Value);

                if (filters.SelectedTypeId.HasValue)
                    dbQuery = dbQuery.Where(x => x.Brand.TypeID == filters.SelectedTypeId.Value);

                List<SocialMediaInfo> dbResults = dbQuery.ToList();
                //foreach (Manufacturer item in dbResults)
                //   result.Add(new KeyValuePair<int, string>(item.MfrID, item.Name));

                foreach (SocialMediaInfo tweet in dbResults)
                {
                    SearchResultEntity temp = new SearchResultEntity();
                    temp.Brand = tweet.Brand.Name;
                    temp.BrandId = tweet.BrandID;
                    temp.Latitude = tweet.Latitude;
                    temp.Longitude = tweet.Longitude;
                    temp.Manufacturer = tweet.Brand.Manufacturer.Name;
                    temp.ManufacturerId = tweet.Brand.MfrID;
                    temp.SearchDate = tweet.SearchDate;
                    temp.Text = tweet.Information;

                    results.Add(temp);
                }
            }

            return results;
        }

    }
}
