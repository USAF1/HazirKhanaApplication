using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.RestaurantManagment
{
    public class RestaurantHandler
    {
        public static void AddRestaurant(Restaurant entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {

                if (entity != null)
                {
                    if (entity.Products != null)
                    {
                        foreach (var product in entity.Products)
                        {
                            context.Entry(product).State = EntityState.Unchanged;
                        }

                    }

                    if (entity.CuisineRestaurants != null)
                    {
                        foreach (var cuisine in entity.CuisineRestaurants)
                        {
                            context.Entry(cuisine.Cuisines).State = EntityState.Unchanged;

                        }
                    }
                    if (entity.City != null)
                    {
                        context.Entry(entity.City).State = EntityState.Unchanged;
                    }
                    if (entity.Provience != null)
                    {
                        context.Entry(entity.Provience).State = EntityState.Unchanged;
                    }

                    context.Add(entity);
                    context.SaveChanges();
                }

            }

        }

        public static List<Restaurant> GetRestaurants()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Restaurants.Include(z => z.CuisineRestaurants).ThenInclude(t => t.Cuisines).Include(x=>x.Provience).Include(o=>o.City).ToList();
            }
        }

        public static Restaurant GetRestaurant(int id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from Restaurant in context.Restaurants where Restaurant.Id == id select Restaurant).Include(x => x.Provience).Include(y => y.City).Include(z => z.CuisineRestaurants).ThenInclude(t=>t.Cuisines).Include(s => s.RestaurantCuisines).ThenInclude(r => r.Products).FirstOrDefault();
            }
        }

        public static void RestaurantAdminUpdate(Restaurant entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {


                if (entity != null)
                {

                    if (entity.Products != null)
                    {
                        foreach (var product in entity.Products)
                        {
                            context.Entry(product).State = EntityState.Unchanged;

                        }
                    }
                    if (entity.City != null)
                    {
                        context.Entry(entity.City).State = EntityState.Unchanged;
                    }
                    if (entity.Provience != null)
                    {
                        context.Entry(entity.Provience).State = EntityState.Unchanged;
                    }
                    if (entity.RestaurantCuisines != null)
                    {
                        foreach (var cuisine in entity.RestaurantCuisines)
                        {
                            context.Entry(cuisine).State = EntityState.Unchanged;

                        }
                    }
                    DeleteCuisineRestaurant(entity.Id);
                    context.Update(entity);
                    context.SaveChanges();
                }
            }
        }

        public static List<Restaurant> GetRandomNineRestaurant()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Restaurants.FromSqlRaw("SELECT top 9 * from dbo.Restaurants").Include(x=>x.CuisineRestaurants).ThenInclude(y=>y.Cuisines).ToList();
            }
        }

        public static void DeleteCuisineRestaurant(int id)
        {
            List<CuisineRestaurant> avaliableList = new List<CuisineRestaurant>();

            using (ApplicationDb context = new ApplicationDb())
            {
                avaliableList = (from CuisineRestaurant in context.CuisineRestaurants where CuisineRestaurant.RestaurantsId == id select CuisineRestaurant).Include(x=>x.Cuisines).Include(y=>y.Restaurants).ToList();

                if (avaliableList != null)
                {
                    foreach (var item in avaliableList)
                    {
                        context.Entry(item.Cuisines).State = EntityState.Unchanged;
                        context.Entry(item.Restaurants).State = EntityState.Unchanged;
                    }
                }
                context.CuisineRestaurants.RemoveRange(avaliableList);
                context.SaveChanges();
            }


        } 


    }
}
