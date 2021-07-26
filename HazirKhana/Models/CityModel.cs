using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class CityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PostalCode { get; set; }

        public ProvienceModel Provience { get; set; }
    }
}
