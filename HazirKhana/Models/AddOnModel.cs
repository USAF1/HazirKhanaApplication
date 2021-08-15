using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class AddOnModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public RestaurantModel Restaurant { get; set; }

        public bool IsSelected { get; set; }
    }
}
