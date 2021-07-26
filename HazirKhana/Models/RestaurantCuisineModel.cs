using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class RestaurantCuisineModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string  Description { get; set; }

        public string Image { get; set; }

        public bool IsChecked { get; set; }

        public RestaurantModel Restaurant { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
