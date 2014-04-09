using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices.DataEntities
{
    public class FilterEntity
    {
        public int? SelectedBrandId { get; set; }
        public int? SelectedManufacturerId { get; set; }
        public int? SelectedTypeId { get; set; }
        public int? MinBarrels { get; set; }
        public int? MaxBarrels { get; set; }
        public decimal? MinSales { get; set; }
        public decimal? MaxSales { get; set; }
        public decimal? MinABV { get; set; }
        public decimal? MaxABV { get; set; }
        public int? MinCalories { get; set; }
        public int? MaxCalories { get; set; }

        public FilterEntity()
        {
        }
    }
}
