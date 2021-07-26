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

    }
}
