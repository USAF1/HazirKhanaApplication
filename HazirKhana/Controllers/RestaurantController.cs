
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Rendering;
using HazirKhanaWEB.Extras;

using Microsoft.AspNetCore.Http;
using System.IO;
using HazirKhana.Models;
using EntityLib.CuisineManagment;
using HazirKhana.Helpers;
using EntityLib.LocationManagment;
using EntityLib.RestaurantManagment;
using EntityLib.ProductsManagment;

namespace HazirKhana.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminRestaurantList()
        {
            List<RestaurantModel> restaurants = RestaurantHandler.GetRestaurants().ToRestaurantModelList();
            ViewData["Restaurants"] = restaurants;
            return View();
        }

        [HttpGet]
        public IActionResult AdminRestaurantAdd()
        {
            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();

            List<SelectListItem> cities = LocationHandler.GetCities().ToCitySelectListItem();

            List<SelectListItem> proviences = LocationHandler.GetProviences().ToProvienceSelectListItem();

            List<SelectListItem> options = ExtrasHandler.OptionsSelectListItem();

            ViewData["Cuisines"] = cuisines;
            ViewData["Cities"] = cities;
            ViewData["Proviences"] = proviences;

            ViewData["Options"] = options;

            return View();
        }

        [HttpPost]
        public IActionResult AdminRestaurantAdd(RestaurantModel model)
        {
            model.City = LocationHandler.GetCity(model.City.Id).ToCityModel();

            model.Provience = LocationHandler.GetProvience(model.Provience.Id).ToProvienceModel();

            Restaurant restaurant = model.ToRestaurantEntity();

            List<CuisineRestaurant> cusines = new List<CuisineRestaurant>();

            foreach (var cuisine in model.Cuisines)
            {
                if (cuisine.IsChecked == true)
                {
                    cusines.Add(new CuisineRestaurant { Cuisines = cuisine.ToCuisineEntity(), CuisinesId = cuisine.Id });
                }
            }

            IFormFile logo = Request.Form.Files["logo"];
            IFormFile banner = Request.Form.Files["banner"];

            restaurant.CuisineRestaurants = cusines;

            restaurant.Banner = banner.FromStringToByteArray();
            restaurant.Logo = logo.FromStringToByteArray();

            RestaurantHandler.AddRestaurant(restaurant);

            return RedirectToAction("Index", "AdminHome");
        }


        [HttpGet]
        public IActionResult AdminSingleRestaurant(int id)
        {
            RestaurantModel restaurant = RestaurantHandler.GetRestaurant(id).ToRestaurantModel();

            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();
            List<SelectListItem> cities = LocationHandler.GetCities().ToCitySelectListItem();

            List<SelectListItem> proviences = LocationHandler.GetProviences().ToProvienceSelectListItem();

            ViewData["Cities"] = cities;
            ViewData["Proviences"] = proviences;

            for (int i = 0; i < cuisines.Count; i++)
            {
                foreach (var item in restaurant.Cuisines)
                {
                    if (item.Id == cuisines[i].Id)
                    {
                        cuisines[i].IsChecked = true;
                    }
                }
            }



            ViewData["Restaurant"] = restaurant;
            ViewData["Cuisines"] = cuisines;

            return View();
        }

        //[HttpPost]
        //public IActionResult AdminRestaurantUpdate(RestaurantModel model)
        //{
        //    if (model.City != null)
        //    {
        //        model.City = LocationHandler.GetCity(model.City.Id).ToCityModel();
        //    }
        //    if (model.Provience != null)
        //    {
        //        model.Provience = LocationHandler.GetProvience(model.Provience.Id).ToProvienceModel();
        //    }


        //    Restaurant restaurant = model.ToRestaurantEntity();

        //    List<Cuisine> selectedCuisine = new List<Cuisine>();

        //    foreach (var SelectedCuisine in model.Cuisines)
        //    {
        //        if (SelectedCuisine.IsChecked == true)
        //        {
        //            selectedCuisine.Add(SelectedCuisine.ToCuisineEntity());
        //        }

        //    }
        //    Restaurant restaurantModel = RestaurantHandler.GetRestaurant(model.Id);


        //    if (model.Logo != null)
        //    {
        //        IFormFile logo = Request.Form.Files["logo"];
        //        restaurant.Logo = logo.FromStringToByteArray();
        //    }
        //    else
        //    {
        //        restaurant.Logo = restaurantModel.Logo;
        //    }
        //    if (model.Banner != null)
        //    {
        //        IFormFile banner = Request.Form.Files["banner"];
        //        restaurant.Banner = banner.FromStringToByteArray();
        //    }
        //    else
        //    {
        //        restaurant.Banner = restaurantModel.Banner;
        //    }
        //    restaurant.Cuisines = selectedCuisine;

        //    RestaurantHandler.RestaurantAdminUpdate(restaurant);

        //    return RedirectToAction("AdminRestaurantsList");
        //}

        public IActionResult AdminProductList()
        {
            List<ProductModel> products = ProductHandler.GetProducts().ToProductModelList();

            ViewData["Products"] = products;
            return View();
        }
    }
}
