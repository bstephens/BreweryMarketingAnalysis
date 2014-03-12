using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialHeatMap.DataServices
{
    public class CoordinateDataService
    {
        public static List<TBL_COORDS> GetAllCoordinates()
        {
            List<TBL_COORDS> result = new List<TBL_COORDS>();

            using (SocialHeatMapEntities context = new SocialHeatMapEntities())
            {
                result = (from a in context.TBL_COORDS
                          select a).ToList();
            }

            return result;
        }
    }
}
