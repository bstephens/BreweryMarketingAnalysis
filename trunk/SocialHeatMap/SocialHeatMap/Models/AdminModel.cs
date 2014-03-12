using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialHeatMap.DataServices.DataEntities;
using SocialHeatMap.DataServices;

namespace SocialHeatMap.Models
{
    public class AdminModel
    {
        public int NumberSearches { get; set; }
        public List<TBL_SEARCH_HISTORY> Searches { get; set; }

        public int NumberUsers { get; set; }
        public List<UserEntity> Users { get; set; }

        public AdminModel()
        {
            Users = new List<UserEntity>();
        }

        public void Load()
        {
            Users = UserDataService.GetAllUsers();
            NumberUsers = Users.Count;

            Searches = AdminDataService.GetSearchHistory(null);
            NumberSearches = Searches.Count;
        }
    }
}