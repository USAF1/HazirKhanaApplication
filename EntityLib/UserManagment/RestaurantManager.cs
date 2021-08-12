using EntityLib.RestaurantManagment;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.UserManagment
{
    public class RestaurantManager
    {
        public int Id { get; set; }

        public Restaurant Restaurant { get; set; }

        public User User { get; set; }


    }
}
