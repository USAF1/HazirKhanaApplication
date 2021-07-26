using EntityLib.RestaurantManagment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.LocationManagment
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar(100)")]
        public string Name { get; set; }

        [Required]
        public int PostalCode { get; set; }

        public Provience Provience { get; set; }

        public List<Restaurant> Restaurants { get; set; }

    }
}
