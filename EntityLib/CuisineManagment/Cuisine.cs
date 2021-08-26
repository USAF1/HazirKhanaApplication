
using EntityLib.RestaurantManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.CuisineManagment
{
    public class Cuisine
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName= "varchar(100)")]
        public string Name { get; set; }


        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        
        public string State { get; set; }

        public virtual List<CuisineRestaurant> CuisineRestaurants { get; set; }

    }
}
