using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.UserManagment
{
    public class RestauranManagerHandler
    {
        public static void AddRestaurantManager(RestaurantManager entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if (entity != null)
                {
                    if (entity.Restaurant != null)
                    {
                        context.Entry(entity.Restaurant).State = EntityState.Unchanged;
                        foreach (var item in entity.Restaurant.CuisineRestaurants)
                        {
                            context.Entry(item).State = EntityState.Unchanged;
                        }
                    }
                    if (entity.User != null)
                    {
                        context.Entry(entity.User).State = EntityState.Unchanged;
                    }

                    context.Add(entity);
                    context.SaveChanges();

                }

            }

        }

        public static List<RestaurantManager> GetRestaurantManagers()
        {
            using (ApplicationDb context =new ApplicationDb())
            {
                return context.RestaurantManagers.Include(x => x.Restaurant).Include(y => y.User).ToList();
            }
        }

        public static RestaurantManager GetRestaurantManager(string Id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from manager in context.RestaurantManagers where manager.User.Id == Id select manager).Include(x=>x.Restaurant).Include(y=>y.User).FirstOrDefault();
            }
        }

    }
}
