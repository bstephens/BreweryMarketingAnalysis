﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;
using SocialHeatMap.DataServices;
using Newtonsoft.Json;
using SocialHeatMap.Models;

namespace SocialHeatMap.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            HomeModel model = new HomeModel(UserInfo.CurrentUsername);
            model.Load();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm, [Bind(Prefix="")]HomeModel model)
        {
            TwitterService service = UserInfo.TwitterService;

            if (service != null)
            {
                SearchOptions myOptions = new SearchOptions();
                myOptions.Q = searchTerm;
                myOptions.Count = 100;
                myOptions.Resulttype = TwitterSearchResultType.Popular;

                long minResultId;

                for (int i = 0; i <= 10; i++)
                {
                    TwitterSearchResult tempResult = service.Search(myOptions);

                    if (tempResult != null && tempResult.Statuses.Count() > 0)
                    {
                        model.Tweets.AddRange(tempResult.Statuses);
                        minResultId = (from a in tempResult.Statuses select a.Id).Min();
                        myOptions.MaxId = minResultId - 1;
                    }
                }

                /*
                List<TBL_COORDS> allCoords = CoordinateDataService.GetAllCoordinates();

                Random rnd = new Random();

                foreach (TwitterStatus item in model.Where(x => x.Location == null))
                {
                    int r = rnd.Next(allCoords.Count);
                    item.Location = new TwitterGeoLocation((double)allCoords[r].LATITUDE, (double)allCoords[r].LONGITUDE);
                }*/

                foreach (TwitterStatus item in model.Tweets.Where(x => x.Location != null))
                    CoordinateDataService.SaveTweet(model.SelectedBrandId, item.TextAsHtml, item.Location.Coordinates.Latitude, item.Location.Coordinates.Longitude);

                string strJson = JsonConvert.SerializeObject(model.Tweets);
                //AdminDataService.SaveSearchResults(UserInfo.CurrentUsername, searchTerm, strJson);
            }
            model.Load();

            return View(model);
        }

        [HttpPost]
        public ActionResult PreviousSearch(int SelectedSearchId)
        {
            HomeModel model = new HomeModel(UserInfo.CurrentUsername);
            model.SelectedSearchId = SelectedSearchId;
            model.Load();

            return View("Index", model);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchData()
        {
            SearchModel model = new SearchModel(UserInfo.CurrentUsername);
            model.Load();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchData([Bind(Prefix="")]SearchModel model)
        {
            model.Load();
            return View(model);
        }
    }
}
