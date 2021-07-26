using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.LocationManagment
{
    public class Provience
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

    }
}
