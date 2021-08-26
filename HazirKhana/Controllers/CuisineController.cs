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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult UpdateCuisine(int id)
        {
            CuisineModel model = CuisineHandler.GetCuisine(id).ToCuisineModel();

            ViewData["State"] = ExtrasHandler.StateSelectListItem();

            return View(model);

        }

        [HttpPost]
        public IActionResult UpdateCuisine(CuisineModel model)
        {
            Cuisine entity = model.ToCuisineEntity();

            Cuisine getentity = CuisineHandler.GetCuisine(model.Id);

            IFormFile image = Request.Form.Files["image"];

            if (image != null)
            {
                entity.Image = image.FromStringToByteArray();
            }
            else
            {
                entity.Image = getentity.Image;
            }

            CuisineHandler.UpdateCuisne(entity);

            return RedirectToAction("AdminIndex");

        }

    }
}
