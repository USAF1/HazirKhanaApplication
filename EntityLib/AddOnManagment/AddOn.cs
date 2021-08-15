using EntityLib.ProductsManagment;
using EntityLib.RestaurantManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.AddOnManagment
{
    public class AddOn
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }

        public Restaurant Restaurant { get; set; }

        public virtual List<AddOnProduct> AddOnProducts { get; set; }
    }
}
