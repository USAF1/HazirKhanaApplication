using EntityLib.AddOnManagment;
using HazirKhana.Helpers;
using HazirKhana.Models;
using HazirKhana.Extras;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HazirKhana.Controllers
{
    [Authorize(Roles = Constants.RestauranAdmin)]
    public class RestaurantAddOnController : Controller
    {
        public int RestraurantId { get; set; }

        public IActionResult Index(int id)
        {
            RestraurantId = id;

            List<AddOnModel> modelList = AddOnHandler.GetAddOns(id).ToModelList();

            ViewData["AddOns"] = modelList;
            return View();
        }

        [HttpGet]
        public IActionResult AddAddon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAddon(AddOnModel model)
        {

            RestaurantManagerModel manager = HttpContext.Session.Get<RestaurantManagerModel>(Constants.Key);
            model.Restaurant = manager.Restaurant;
            AddOnHandler.AddAddOn(model.ToEntity());

            return RedirectToAction("index", "RestaurantAdmin");
        }
    }
}
