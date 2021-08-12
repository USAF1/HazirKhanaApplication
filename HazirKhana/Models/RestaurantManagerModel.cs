using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class RestaurantManagerModel
    {
        public int Id { get; set; }

        public UserModel User { get; set; }

        public RestaurantModel Restaurant { get; set; }

    }
}
