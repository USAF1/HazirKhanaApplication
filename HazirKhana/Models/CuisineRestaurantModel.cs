
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class CuisineRestaurantModel
    {
        public int CuisinesId { get; set; }
        public int RestaurantsId { get; set; }

        public virtual CuisineModel Cuisines { get; set; }
        public virtual RestaurantModel Restaurants { get; set; }
    }
}
