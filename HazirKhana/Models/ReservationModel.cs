using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class ReservationModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int TableFor { get; set; }

        public long Contact { get; set; }

        public DateTime Time { get; set; }


    }
}
