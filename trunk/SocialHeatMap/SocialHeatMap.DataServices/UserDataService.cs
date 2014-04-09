using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialHeatMap.DataServices.DataEntities;

namespace SocialHeatMap.DataServices
{
    public static class UserDataService
    {
        public static UserEntity SaveUser(string username, string name, string accessToken, string accessTokenSecret)
        {
            UserEntity result;

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {

                User dbUser = (from a in context.Users
                                   where a.ScreenName == username
                                   select a).ToList().FirstOrDefault();

                if (dbUser == null)
                {
                    dbUser = new User();
                    dbUser.ScreenName = username;
                    dbUser.FirstName = name;
                    dbUser.LastName = name;
                    dbUser.CreatedOn = DateTime.Now;
                    dbUser.IsAdmin = false;
                    dbUser.IsSubscribed = false;

                    context.Users.AddObject(dbUser);
                }

                dbUser.AccessToken = accessToken;
                dbUser.AccessTokenSecret = accessTokenSecret;

                context.SaveChanges();

                result = (from a in context.Users
                          where a.ScreenName == username
                          select new UserEntity()
                          {
                              UserId = a.UserID,
                              Name = a.FirstName,
                              ScreenName = a.ScreenName,
                              IsAdmin = a.IsAdmin,
                              IsSubscribed = a.IsSubscribed,
                              AccessToken = a.AccessToken,
                              AccessTokenSecret = a.AccessTokenSecret,
                              CreatedDt = a.CreatedOn
                          }).First();
            }

            return result;
        }

        public static UserEntity GetUser(string username)
        {
            UserEntity result;

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.Users
                          where a.ScreenName == username
                          select new UserEntity()
                          {
                              UserId = a.UserID,
                              Name = a.FirstName,
                              ScreenName = a.ScreenName,
                              IsAdmin = a.IsAdmin,
                              IsSubscribed = a.IsSubscribed,
                              AccessToken = a.AccessToken,
                              AccessTokenSecret = a.AccessTokenSecret,
                              CreatedDt = a.CreatedOn
                          }).First();
            }

            return result;
        }

        public static List<UserEntity> GetAllUsers()
        {
            List<UserEntity> result;

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.Users
                          select new UserEntity()
                          {
                              UserId = a.UserID,
                              Name = a.FirstName,
                              ScreenName = a.ScreenName,
                              IsAdmin = a.IsAdmin,
                              IsSubscribed = a.IsSubscribed,
                              AccessToken = a.AccessToken,
                              AccessTokenSecret = a.AccessTokenSecret,
                              CreatedDt = a.CreatedOn
                          }).ToList();
            }

            return result;
        }
    }
}
