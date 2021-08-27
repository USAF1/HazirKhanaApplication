using EntityLib.CuisineManagment;
using EntityLib.ProductsManagment;
using EntityLib.RestaurantManagment;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {



            List<ProductModel> products = ProductHandler.GetTopNineProducts().ToProductModelList();

            List<RestaurantModel> restaurants = RestaurantHandler.GetRandomNineRestaurant().ToRestaurantModelList();
            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();

            ViewData["Products"] = products;
            ViewData["Restaurants"] = restaurants;
            ViewData["Cuisines"] = cuisines;
            return View();
        }
    }
}
