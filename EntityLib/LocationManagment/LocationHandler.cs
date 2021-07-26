using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.LocationManagment
{
    public class LocationHandler
    {

        public static void AddCity(City entity)
        {
            if (entity!=null)
            {
                using (ApplicationDb context =new ApplicationDb())
                {
                    if (entity.Provience != null)
                    {
                        context.Entry(entity.Provience).State = EntityState.Unchanged;
                    }
                    if (entity.Restaurants != null)
                    {
                        foreach (var item in entity.Restaurants)
                        {
                            context.Entry(item).State = EntityState.Unchanged;
                        }
                        
                    }

                    context.Cities.Add(entity);
                    context.SaveChanges();
                }
            }
        }


        public static void AddProvience(Provience entity)
        {
            if (entity != null)
            {
                using (ApplicationDb context = new ApplicationDb())
                {
                    context.Proviences.Add(entity);
                    context.SaveChanges();
                }
            }
        }

        public static List<City> GetCities()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Cities.Include(x=>x.Provience).ToList();
            }
        }
        public static List<Provience> GetProviences()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Proviences.ToList();
            }
        }

        public static City GetCity(int Id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Cities.Find(Id);
            }
        }



        public static Provience GetProvience(int Id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {

                return context.Proviences.Find(Id);
            }
        }

        public static Provience GetProvience(string Name)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from Provience in context.Proviences where Provience.Name == Name select Provience).FirstOrDefault();
            }
        }

    }
}
