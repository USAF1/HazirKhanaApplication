using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.CuisineManagment
{
    public static class CuisineHandler
    {

        public static void AddCusine( this Cuisine entity)
        {

            using (ApplicationDb context = new ApplicationDb())
            {
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public static List<Cuisine> GetCuisines()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Cuisines.Include(x=>x.ParentCuisine).ToList();
            }
        }

        public static Cuisine GetCuisine(int id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from Cuisine in context.Cuisines where Cuisine.Id == id select Cuisine).FirstOrDefault();
            }
        }


    }
}
