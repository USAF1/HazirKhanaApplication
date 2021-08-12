using EntityLib.RestaurantManagment;
using EntityLib.UserManagment;
using HazirKhana.Extras;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    [Authorize]
    public class RestaurantAdminController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _usermanager;

        public RestaurantAdminController(SignInManager<IdentityUser> singInmanager, UserManager<IdentityUser> usermanager)
        {
            _signInManager = singInmanager;
            _usermanager = usermanager;
        }

        public async  Task<IActionResult> Index()
        {
            var result = await _usermanager.GetUserAsync(HttpContext.User);

            RestaurantManagerModel manager = HttpContext.Session.Get<RestaurantManagerModel>(Constants.Key );

            RestaurantModel restaurant = RestaurantHandler.GetRestaurant(manager.Restaurant.Id).ToRestaurantModel();

            ViewData["Restaurant"] = restaurant;
            return View();
        }
    }
}
