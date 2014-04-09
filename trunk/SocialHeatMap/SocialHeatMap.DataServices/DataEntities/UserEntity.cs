using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices.DataEntities
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSubscribed { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public DateTime CreatedDt { get; set; }
    }
}
