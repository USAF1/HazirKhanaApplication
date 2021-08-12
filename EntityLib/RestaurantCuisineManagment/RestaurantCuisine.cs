using EntityLib.ProductsManagment;
using EntityLib.RestaurantManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.RestaurantCuisineManagment
{
    public class RestaurantCuisine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName= "varchar(max)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public Restaurant Restaurant { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
