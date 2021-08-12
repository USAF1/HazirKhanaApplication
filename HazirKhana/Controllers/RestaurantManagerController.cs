using EntityLib.RestaurantManagment;
using EntityLib.UserManagment;
using HazirKhana.Helpers;
using HazirKhana.Models;
using HazirKhana.Extras;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class RestaurantManagerController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;

        public RestaurantManagerController(UserManager<IdentityUser> UserManager)
        {
            _usermanager = UserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminRestaurntManagerList()
        {
            List<RestaurantManagerModel> managers = RestauranManagerHandler.GetRestaurantManagers().ToRestaurantManagerList();

            ViewData["Managers"] = managers;
            return View();
        }

        [HttpGet]
        public IActionResult AddManager()
        {
            List<SelectListItem> restaurants = RestaurantHandler.GetRestaurants().ToRestaurantSelectList();

            ViewData["Restaurants"] = restaurants;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(RestaurantManagerModel model)
        {
            User user = new User() { Name = model.User.Name, Address = model.User.Address, Email = model.User.Email, PhoneNumber = model.User.PhoneNumber, UserName = model.User.Email };

            IFormFile image = Request.Form.Files["image"];
            user.Image = image.FromStringToByteArray();

            var result = await _usermanager.CreateAsync(user, model.User.PasswordHash);
           
            if (result.Succeeded)
            {
                await _usermanager.AddToRoleAsync(user, "Restaurant Admin");

                RestaurantManager entity = new RestaurantManager();
                entity.Restaurant = RestaurantHandler.GetRestaurant(model.Restaurant.Id);
                entity.User = user;

                RestauranManagerHandler.AddRestaurantManager(entity);

                return RedirectToAction("AdminRestaurntManagerList");
            }
            return View(model);
        }

    }
}
