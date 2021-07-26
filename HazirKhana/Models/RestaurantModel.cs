using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public long ContactMob { get; set; }

        public long ConatctTel { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public ProvienceModel Provience { get; set; }

        public CityModel City { get; set; }

        public int PostalCode { get; set; }

        public string Discription { get; set; }

        public List<CuisineModel> Cuisines {get; set; }

        public List<ProductModel> Products { get; set; }

        public int  SalesTax { get; set; }

        public int OrderLedTime { get; set; }

        public int PercentageCutOff { get; set; }

        public string Reservation { get; set; }

        public string Logo { get; set; }

        public string Banner { get; set; }

        public List<RestaurantCuisineModel> RestaurantCuisines { get; set; }


    }
}

