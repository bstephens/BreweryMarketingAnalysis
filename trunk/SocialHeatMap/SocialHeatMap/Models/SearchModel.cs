using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
using SocialHeatMap.DataServices;
using Newtonsoft.Json;
using SocialHeatMap.DataServices.DataEntities;

namespace SocialHeatMap.Models
{
    public class SearchModel
    {
        private string _username;

        public SelectList Brands { get; set; }
        public SelectList Manufacturers { get; set; }
        public SelectList Types { get; set; }
        public FilterEntity Filters { get; set; }

        public List<SearchResultEntity> SearchResults { get; set; }

        public SearchModel()
        {
            Filters = new FilterEntity();
        }

        public SearchModel(string username)
        {
            _username = username;
            Filters = new FilterEntity();
        }

        public void Load()
        {

            /*
             * Brands by them self
             * Manufacturer dd
             * Type
             * Barrels 0-500,000, 501,000 - 1,000,000, > 1,000,000
             * Sales 0-100M, 100-500M, > 500M
             * ABV < 4, 4.01-5, 5.01-6, 6.01 - 7, > 7
             * Calories < 150, 150-200, > 200
             */

            Brands = new SelectList(BeerDataService.GetAllBrands(), "key", "value", Filters.SelectedBrandId);
            Types = new SelectList(BeerDataService.GetAllTypes(), "key", "value", Filters.SelectedTypeId);
            Manufacturers = new SelectList(BeerDataService.GetAllManufacturers(), "key", "value", Filters.SelectedManufacturerId);

            SearchResults = BeerDataService.GetSearchResults(Filters);
            
        }
    }
}
