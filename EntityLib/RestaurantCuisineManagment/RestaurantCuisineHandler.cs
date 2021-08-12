using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.RestaurantCuisineManagment
{
    public static class RestaurantCuisineHandler
    {
        public static void AddRestaurantCuisine(RestaurantCuisine entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if(entity != null)
                {
                    if (entity.Restaurant != null)
                    {
                        context.Entry(entity.Restaurant).State = EntityState.Unchanged;
                    }
                    context.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public static List<RestaurantCuisine> GetAllCuisines()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.RestaurantCuisines.Include(x=>x.Restaurant).ToList();
            }
        }

        public static List<RestaurantCuisine> GetRestaurantCuisines(int Id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {

                return (from Cuisine in context.RestaurantCuisines where Cuisine.Restaurant.Id == Id select Cuisine).ToList();
            }
        }

        public static RestaurantCuisine GetCuisine(int id)
        {
            using (ApplicationDb context =new ApplicationDb())
            {
                return context.RestaurantCuisines.FirstOrDefault(x => x.Id == id);
            }
        }


        public static void UpdateRestaurantCuisine(RestaurantCuisine entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if (entity.Restaurant != null)
                {
                    context.Entry(entity.Restaurant).State = EntityState.Unchanged;
                }
                if (entity.Products != null)
                {
                    context.Entry(entity.Products).State = EntityState.Unchanged;
                }

                context.RestaurantCuisines.Update(entity);
            }
        }
    }
}
