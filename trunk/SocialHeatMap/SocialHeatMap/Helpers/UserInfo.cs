using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialHeatMap.DataServices.DataEntities;
using SocialHeatMap.DataServices;
using TweetSharp;
using System.Configuration;

namespace SocialHeatMap
{
    public static class UserInfo
    {
        private static string _consumerKey = ConfigurationManager.AppSettings["token_ConsumerKey"];
        private static string _consumerSecret = ConfigurationManager.AppSettings["token_ConsumerSecret"];

        public static string CurrentUsername
        {
            get
            {
                //Get the current user id if the user is authenticated
                string username = null;

                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    username = HttpContext.Current.User.Identity.Name;

                //Return the current user id
                return username;
            }
        }

        public static UserEntity CurrentUser
        {
            get
            {
                //Return the current user
                UserEntity user = null;

                //Get the current user id
                string username = CurrentUsername;

                if (!String.IsNullOrEmpty(username))
                {
                    //Check the temp data first (only look this up once per request)
                    user = (UserEntity)HttpContext.Current.Items["CurrentUserInstance"];

                    //If no user was found in the per-request cache items, look it up
                    if (user == null)
                    {
                        //Look up the user entity
                        user = UserDataService.GetUser(username);

                        //If found, store it in the context items
                        if (user != null)
                            HttpContext.Current.Items.Add("CurrentUserInstance", user);
                    }
                }

                //Return the current user
                return user;
            }
        }

        public static TwitterService TwitterService
        {
            get
            {
                TwitterService result = null;

                //Get the current user id
                string username = CurrentUsername;

                if (!String.IsNullOrEmpty(username))
                {
                    //Check the temp data first (only look this up once per request)
                    result = (TwitterService)HttpContext.Current.Items["TwitterService"];

                    //If no user was found in the per-request cache items, look it up
                    if (result == null)
                    {
                        //create the twitter service
                        result = new TwitterService(_consumerKey, _consumerSecret);
                        result.AuthenticateWith(CurrentUser.AccessToken, CurrentUser.AccessTokenSecret);

                        //If found, store it in the context items
                        if (result != null)
                            HttpContext.Current.Items.Add("TwitterService", result);
                    }
                }

                //Return the current user
                return result;

            }
        }

    }
}
