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
    public class User : IdentityUser
    {

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Address { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
    }
}
