using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.ProductsManagment
{
    public static class ProductHandler
    {
        //public static List<Product> GetProducts()
        //{
        //    using (ApplicationDb context  =new ApplicationDb())
        //    {
        //        return context.Products.Include(x=>x.Restaurant).Include(y=>y.Cuisine).ToList();
        //    }
        //}

        //public static Product GetProduct(int Id)
        //{
        //    using (ApplicationDb context = new ApplicationDb())
        //    {
        //        return (from Product in context.Products where Product.Id == Id select Product).FirstOrDefault();
        //    }
        //}

    }
}
