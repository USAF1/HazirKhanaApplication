
using EntityLib.RestaurantCuisineManagment;
using EntityLib.RestaurantManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.ProductsManagment
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar(max)")]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public Restaurant Restaurant { get; set; }
        
        [Required]
        public RestaurantCuisine Cuisine { get; set; }
    }
}
