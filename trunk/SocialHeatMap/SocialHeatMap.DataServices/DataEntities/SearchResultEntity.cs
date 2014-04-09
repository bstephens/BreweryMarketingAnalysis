using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices.DataEntities
{
    public class SearchResultEntity
    {
        public string Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public string Text { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime SearchDate { get; set; }
    }
}
