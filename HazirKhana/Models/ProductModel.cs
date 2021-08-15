using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int  Price { get; set; }

        public string Discription { get; set; }

        public RestaurantCuisineModel Cuisine { get; set; }

        public string Image { get; set; }

        public RestaurantModel Restaurant { get; set; }

        public ProductVariationModel Variations { get; set; }

        public List<AddOnModel> AddOns { get; set; }

    }
}
