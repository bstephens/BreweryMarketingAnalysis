using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices
{
    public class AdminDataService
    {
        public static void SaveSearchResults(string username, string searchString, string jsonResult)
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                TBL_SEARCH_HISTORY tempItem = new TBL_SEARCH_HISTORY();
                tempItem.USER_ID = (from a in context.TBL_USER where a.SCREENNAME == username select a.USER_ID).First();
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
                results = (from a in context.TBL_SEARCH_HISTORY.Include("TBL_USER")
                           where String.IsNullOrEmpty(username) || a.TBL_USER.SCREENNAME == username
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
        }

        public static void ClearUserCredentials()
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                List<TBL_USER> dbUsers = (from a in context.TBL_USER
                                          select a).ToList();

                foreach (TBL_USER user in dbUsers)
                {
                    user.ACCESS_TOKEN = "";
                    user.ACCESS_TOKEN_SECRET = "";
                }

                context.SaveChanges();
            }
        }

        public static void UpdateAdminStatus(int userId, bool isAdmin)
        {
            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                TBL_USER dbUser = (from a in context.TBL_USER
                                   where a.USER_ID == userId
                                   select a).First();

                dbUser.IS_ADMIN = isAdmin;

                context.SaveChanges();
            }
        }
    }
}
