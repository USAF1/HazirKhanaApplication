using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HazirKhana.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazirKhana.Models;

using EntityLib.CuisineManagment;
using HazirKhana.Helpers;

namespace HazirKhana.Controllers
{
    public class CuisineController : Controller
    {

        public IActionResult AdminIndex()
        {
            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();

            ViewData["Cuisines"] = cuisines;
            return View();
        }

        [HttpPost]
        public IActionResult AddCuisine(CuisineModel model)
        {
            Cuisine entity = model.ToCuisineEntity();

            IFormFile image = Request.Form.Files["image"];

            entity.Image = image.FromStringToByteArray();

            CuisineHandler.AddCusine(entity);

            return RedirectToAction("AdminIndex");
        }

    }
}
