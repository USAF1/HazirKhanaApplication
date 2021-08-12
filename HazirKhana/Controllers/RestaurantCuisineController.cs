using HazirKhana.Extras;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace HazirKhana.Controllers
{
    public class RestaurantCuisineController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;

        public RestaurantCuisineController(UserManager<IdentityUser> usermanager)
        {
            _usermanager = usermanager;
        }


        public IActionResult Index(int id)
        {

            List<RestaurantCuisineModel> Cuisines = RestaurantCuisineHandler.GetRestaurantCuisines(id).ToRestaurantCuisineModelList();

            ViewData["Cuisine"] = Cuisines;

            return View();
        }

        [HttpGet]
        public IActionResult AddRestaurantCuisine()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddRestaurantCuisine(RestaurantCuisineModel model)
        {
            RestaurantManagerModel manager = HttpContext.Session.Get<RestaurantManagerModel>(Constants.Key);
            model.Restaurant = manager.Restaurant;
            model.Status = Constants.ActiveStatus;
            RestaurantCuisine entity = model.ToRestaurantCuisineEntity();

            IFormFile Image = Request.Form.Files["image"];
            entity.Image = Image.FromStringToByteArray();


            RestaurantCuisineHandler.AddRestaurantCuisine(entity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRestaurantCuisine(int id)
        {
            RestaurantCuisineModel model = RestaurantCuisineHandler.GetCuisine(id).ToRestaurantCuisineModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateRestaurantCuisine(RestaurantCuisineModel model)
        {
            model.Status = Constants.ActiveStatus;
            RestaurantCuisine entity = RestaurantCuisineHandler.GetCuisine(model.Id);

            if (model != null)
            {
                entity.Name = model.Name;
                entity.Description = model.Description;

                IFormFile image = Request.Form.Files["image"];
                if (image != null)
                {
                    entity.Image = image.FromStringToByteArray();
                }
            }

            RestaurantCuisineHandler.UpdateRestaurantCuisine(entity);

            return RedirectToAction("Index", "RestaurantAdmin");
        }
    }
}
