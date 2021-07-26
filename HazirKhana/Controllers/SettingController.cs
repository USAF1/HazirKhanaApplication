using EntityLib.LocationManagment;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Index()
        {
            List<ProvienceModel> proviences = LocationHandler.GetProviences().ToProvienceModelList();

            List<CityModel> citites = LocationHandler.GetCities().ToCityModelList();

            List<SelectListItem> provienceList = LocationHandler.GetProviences().ToProvienceSelectListItem();

            ViewData["Proviences"] = proviences;
            ViewData["ProvienceList"] = provienceList;
            ViewData["Cities"] = citites;
            return View();
        }

        public IActionResult AddProvience(ProvienceModel model)
        {
            if (model != null)
            {
                LocationHandler.AddProvience(model.ToProvieceEntity());
            }

            return RedirectToAction("Index");
        }


        public IActionResult AddCity(CityModel model)
        {
            if (model != null)
            {
                model.Provience = LocationHandler.GetProvience(model.Provience.Id).ToProvienceModel();
                LocationHandler.AddCity(model.ToCityEntity());
            }

            return RedirectToAction("Index");
        }
    }
}
