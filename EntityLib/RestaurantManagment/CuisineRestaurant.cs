using EntityLib.CuisineManagment;
using System;
using System.Collections.Generic;


namespace EntityLib.RestaurantManagment
{
    public partial class CuisineRestaurant
    {
        public int CuisinesId { get; set; }
        public int RestaurantsId { get; set; }

        public virtual Cuisine Cuisines { get; set; }
        public virtual Restaurant Restaurants { get; set; }
    }
}
