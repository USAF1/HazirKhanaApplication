using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.AddOnManagment
{
    public class AddOnHandler
    {

        public static void AddAddOn(AddOn entity)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if (entity.Restaurant != null)
                {
                    context.Entry(entity.Restaurant).State = EntityState.Unchanged;
                }

                context.Add(entity);
                context.SaveChanges();
            }
        }


        public static List<AddOn> GetAddOns(int id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {

                return (from AddOn in context.AddOns where AddOn.Restaurant.Id == id select AddOn).ToList();
            }
        }

        public static AddOn GetAddOn(int id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {

                return context.AddOns.FirstOrDefault(x => x.Id == id);
            }
        }

    }
}
