using EntityLib.AddOnManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.ProductsManagment
{
    public class AddOnProduct
    {
        public int ProductId { get; set; }

        public int AddOnId { get; set; }


        public virtual Product Products{ get; set; }

        public virtual AddOn AddOns { get; set; }

    }
}
