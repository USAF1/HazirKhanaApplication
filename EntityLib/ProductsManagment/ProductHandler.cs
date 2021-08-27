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
        public static List<Product> GetProducts()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Products.Include(x => x.Restaurant).Include(y => y.Cuisine).Include(z=>z.Variations).Include(c=>c.AddOnProducts).ToList();
            }
        }

        public static Product GetProduct(int Id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from Product in context.Products where Product.Id == Id select Product).FirstOrDefault();
            }
        }

        public static List<Product> GetRestaurntProducts(int restaurantId)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from Products in context.Products where Products.Restaurant.Id == restaurantId select Products).Include(x=>x.Cuisine).Include(x=>x.Variations).ToList();
            }
        }


        public static List<Product> GetTopNineProducts()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Products.FromSqlRaw("SELECT top 9 * from dbo.Products").Include(x => x.Cuisine).Include(y=>y.Restaurant).Include(z=>z.Variations).ToList();
            }
        }

        public static void AddProduct(Product entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if (entity != null)
                {
                    if (entity.Restaurant != null )
                    {
                        context.Entry(entity.Restaurant).State = EntityState.Unchanged;
                    }
                    if (entity.Cuisine != null)
                    {
                        context.Entry(entity.Cuisine).State = EntityState.Unchanged;
                    }

                    if (entity.AddOnProducts !=null)
                    {
                        foreach (var item in entity.AddOnProducts)
                        {
                            context.Entry(item.AddOns).State = EntityState.Unchanged;
                        }
                    }
                    if (entity.Variations != null)
                    {
                        context.Entry(entity.Variations).State = EntityState.Added;
                    }

                    context.Add(entity);
                    context.SaveChanges();

                }


            }
        }

    }
}
