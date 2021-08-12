using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class UserModel : IdentityUser
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public string Image { get; set; }
    }
}
