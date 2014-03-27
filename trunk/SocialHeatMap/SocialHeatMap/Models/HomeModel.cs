using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
using SocialHeatMap.DataServices;
using Newtonsoft.Json;

namespace SocialHeatMap.Models
{
    public class HomeModel
    {
        private string _username;

        public List<TwitterStatus> Tweets { get; set; }
        public int? SelectedSearchId { get; set; }
        public SelectList PreviousSearches { get; set; }
        public int SelectedBrandId { get; set; }
        public SelectList Brands { get; set; }

        public HomeModel()
        {
            Tweets = new List<TwitterStatus>();
        }

        public HomeModel(string username)
        {
            Tweets = new List<TwitterStatus>();
            _username = username;
        }

        public void Load()
        {
            //List<TBL_SEARCH_HISTORY> dbHistory = AdminDataService.GetSearchHistory(_username);
            //List<KeyValuePair<int, string>> results = (from a in dbHistory select new KeyValuePair<int, string>(a.SEARCH_ID, a.SEACH_TEXT + "(" + a.CREATED_DT.ToShortDateString() + ")")).ToList();
            //PreviousSearches = new SelectList(results, "key", "value", SelectedSearchId);

            Brands = new SelectList(BeerDataService.GetAllBrands(), "key", "value", SelectedBrandId);

            if (SelectedSearchId.HasValue)
            {
                //TBL_SEARCH_HISTORY result = (from a in dbHistory where a.SEARCH_ID == SelectedSearchId select a).First();

                //Tweets = (List<TwitterStatus>)JsonConvert.DeserializeObject<List<TwitterStatus>>(result.RESULTS);
            }
            
        }
    }
}
