
using HazirKhanaWEB.Extras;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using HazirKhana.Models;
using EntityLib.RestaurantCuisineManagment;
using HazirKhana.Helpers;
using EntityLib.RestaurantManagment;

namespace HazirKhana.Controllers
{
    public class RestaurantCuisineController : Controller
    {
        //public IActionResult Index()
        //{
        //    List<RestaurantCuisineModel> Cuisines = RestaurantCuisineHandler.GetRestaurantCuisines(1).ToRestaurantCuisineModelList();

        //    ViewData["Cuisine"] = Cuisines;

        //    return View();
        //}

        //[HttpGet]
        //public IActionResult AddRestaurantCuisine()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult AddRestaurantCuisine(RestaurantCuisineModel model)
        //{
        //        RestaurantCuisine entity = model.ToRestaurantCuisineEntity();

        //    entity.Restaurant = RestaurantHandler.GetRestaurant(1);

        //        if (model.Image != null)
        //        {
        //            IFormFile Image = Request.Form.Files["image"];
        //            entity.Image = Image.FromStringToByteArray();
        //        }

        //    RestaurantCuisineHandler.AddRestaurantCuisine(entity);

        //    return RedirectToAction("Index");
        //}
    }
}
