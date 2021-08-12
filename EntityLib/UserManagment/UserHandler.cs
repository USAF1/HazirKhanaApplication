using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.UserManagment
{
    public class UserHandler
    {
        public static User GetUser(string id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Users.FirstOrDefault(x=>x.Id == id);
            }
        }

        public static List<User> GetUsers()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Users.ToList();
            }
        }


    }
}
