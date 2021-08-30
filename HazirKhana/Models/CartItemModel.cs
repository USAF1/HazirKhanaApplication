using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        public CartitemVariation ProductVariation { get; set; }

        public List<AddOnModel> ItemAddOns { get; set; }

    }
}
