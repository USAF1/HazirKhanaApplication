using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.ProductsManagment
{
    public class ProductVaration
    {
        public int Id { get; set; }

        [Column(TypeName ="varchar(50)")]
        public string Small { get; set; }

        public int SmallPrice { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Medium { get; set; }

        public int MediumPrice { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Large { get; set; }

        public int LargePrice { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ExtraLarge { get; set; }

        public int XlPrice { get; set; }

    }
}
