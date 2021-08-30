using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class ProductVariationModel
    {
        public int Id { get; set; }

        public string Small { get; set; }

        public int SmallPrice { get; set; }

        public bool IsSelectedSmall { get; set; }

        public string Medium { get; set; }

        public int MediumPrice { get; set; }

        public bool IsSelectedMedium { get; set; }
        public string Large { get; set; }

        public int LargePrice { get; set; }

        public bool IsSelectedLarge { get; set; }

        public string ExtraLarge { get; set; }

        public int XlPrice { get; set; }

        public bool IsSelectedExtraLarge { get; set; }

    }
}
