using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocialHeatMap.DataServices.DataEntities;

namespace SocialHeatMap.DataServices
{
    public class UserDataService
    {
        public static UserEntity SaveUser(string username, string name, string accessToken, string accessTokenSecret)
        {
            UserEntity result;

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {

                TBL_USER dbUser = (from a in context.TBL_USER
                                   where a.SCREENNAME == username
                                   select a).ToList().FirstOrDefault();

                if (dbUser == null)
                {
                    dbUser = new TBL_USER();
                    dbUser.SCREENNAME = username;
                    dbUser.FIRST_NAME = name;
                    dbUser.LAST_NAME = name;
                    dbUser.CREATED_DT = DateTime.Now;
                    dbUser.IS_ADMIN = false;

                    context.TBL_USER.AddObject(dbUser);
                }

                dbUser.ACCESS_TOKEN = accessToken;
                dbUser.ACCESS_TOKEN_SECRET = accessTokenSecret;

                context.SaveChanges();

                result = (from a in context.TBL_USER
                          where a.SCREENNAME == username
                          select new UserEntity()
                          {
                              UserId = a.USER_ID,
                              Name = a.FIRST_NAME,
                              ScreenName = a.SCREENNAME,
                              IsAdmin = a.IS_ADMIN,
                              AccessToken = a.ACCESS_TOKEN,
                              AccessTokenSecret = a.ACCESS_TOKEN_SECRET,
                              CreatedDt = a.CREATED_DT
                          }).First();
            }

            return result;
        }

        public static UserEntity GetUser(string username)
        {
            UserEntity result;

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.TBL_USER
                          where a.SCREENNAME == username
                          select new UserEntity()
                          {
                              UserId = a.USER_ID,
                              Name = a.FIRST_NAME,
                              ScreenName = a.SCREENNAME,
                              IsAdmin = a.IS_ADMIN,
                              AccessToken = a.ACCESS_TOKEN,
                              AccessTokenSecret = a.ACCESS_TOKEN_SECRET,
                              CreatedDt = a.CREATED_DT
                          }).First();
            }

            return result;
        }

        public static List<UserEntity> GetAllUsers()
        {
            List<UserEntity> result;

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.TBL_USER
                          select new UserEntity()
                          {
                              UserId = a.USER_ID,
                              Name = a.FIRST_NAME,
                              ScreenName = a.SCREENNAME,
                              IsAdmin = a.IS_ADMIN,
                              AccessToken = a.ACCESS_TOKEN,
                              AccessTokenSecret = a.ACCESS_TOKEN_SECRET,
                              CreatedDt = a.CREATED_DT
                          }).ToList();
            }

            return result;
        }
    }
}
