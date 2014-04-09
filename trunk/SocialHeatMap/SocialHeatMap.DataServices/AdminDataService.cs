using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices
{
    public static class AdminDataService
    {
        /*public static void SaveSearchResults(string username, string searchString, string jsonResult)
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                TBL_SEARCH_HISTORY tempItem = new TBL_SEARCH_HISTORY();
                tempItem.USER_ID = (from a in context.User where a.SCREENNAME == username select a.USER_ID).First();
                tempItem.SEACH_TEXT = searchString;
                tempItem.RESULTS = jsonResult;
                tempItem.CREATED_DT = DateTime.Now;

                context.TBL_SEARCH_HISTORY.AddObject(tempItem);
                context.SaveChanges();
            }
        }

        public static List<TBL_SEARCH_HISTORY> GetSearchHistory(string username)
        {
            List<TBL_SEARCH_HISTORY> results = new List<TBL_SEARCH_HISTORY>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                results = (from a in context.TBL_SEARCH_HISTORY.Include("User")
                           where String.IsNullOrEmpty(username) || a.User.SCREENNAME == username
                           orderby a.CREATED_DT descending
                           select a).ToList();
            }

            return results;
        }

        public static TBL_SEARCH_HISTORY GetSearchResult(int searchId)
        {
            TBL_SEARCH_HISTORY result = new TBL_SEARCH_HISTORY();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.TBL_SEARCH_HISTORY
                           where a.SEARCH_ID == searchId
                           select a).First();
            }

            return result;
        }

        public static void ClearSearches()
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                context.ExecuteStoreCommand("TRUNCATE TABLE dbo.TBL_SEARCH_HISTORY");
            }
        }*/

        public static void ClearUserCredentials()
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                List<User> dbUsers = (from a in context.Users
                                          select a).ToList();

                foreach (User user in dbUsers)
                {
                    user.AccessToken = "";
                    user.AccessTokenSecret = "";
                }

                context.SaveChanges();
            }
        }

        public static void UpdateAdminStatus(int userId, bool isAdmin)
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                User dbUser = (from a in context.Users
                                   where a.UserID == userId
                                   select a).First();

                dbUser.IsAdmin = isAdmin;

                context.SaveChanges();
            }
        }

        public static void UpdateSubscriberStatus(int userId, bool isSubscriber)
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                User dbUser = (from a in context.Users
                               where a.UserID == userId
                               select a).First();

                dbUser.IsSubscribed = isSubscriber;

                context.SaveChanges();
            }
        }
    }
}
