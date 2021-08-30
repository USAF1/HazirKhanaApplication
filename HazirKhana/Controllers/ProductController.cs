using EntityLib.AddOnManagment;
using EntityLib.CuisineManagment;
using EntityLib.ProductsManagment;
using EntityLib.RestaurantCuisineManagment;
using EntityLib.RestaurantManagment;
using HazirKhana.Extras;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int? pageNumber)
        {
            int pageSize = 9;

            List<ProductModel> products = ProductHandler.GetProducts().ToProductModelList();

            List<CuisineModel> cuisines = CuisineHandler.GetCuisines().ToCuisineModelList();

            ViewData["Cuisines"] = cuisines;
            return View(PaginatedList<ProductModel>.CreateAsync(products, pageNumber ?? 1, pageSize));
        }

        public IActionResult RestauranAdminProductList()
        {
            RestaurantManagerModel manager = HttpContext.Session.Get<RestaurantManagerModel>(Constants.Key);
            List<ProductModel> products = ProductHandler.GetRestaurntProducts(manager.Restaurant.Id).ToProductModelList();

            ViewData["Products"] = products;


            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            RestaurantManagerModel manager = HttpContext.Session.Get<RestaurantManagerModel>(Constants.Key);

            List<SelectListItem> cuisine = RestaurantCuisineHandler.GetRestaurantCuisines(manager.Restaurant.Id).ToRestaurantCuisineSelectListitem();

            List<AddOnModel> addons = AddOnHandler.GetAddOns(manager.Restaurant.Id).ToModelList();

            ViewData["Cuisines"] = cuisine;
            ViewData["AddOns"] = addons;

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {
            RestaurantManagerModel manager = HttpContext.Session.Get<RestaurantManagerModel>(Constants.Key);

            model.Restaurant = RestaurantHandler.GetRestaurant(manager.Restaurant.Id).ToRestaurantModel();

            model.Cuisine = RestaurantCuisineHandler.GetCuisine(model.Cuisine.Id).ToRestaurantCuisineModel();

            List<AddOnProduct> Addons = new List<AddOnProduct>();

            foreach (var addon in model.AddOns)
            {
                if (addon.IsSelected == true)
                {
                    Addons.Add(new AddOnProduct { AddOnId =  addon.Id, AddOns = addon.ToEntity()});
                }
            }

            Product entity = model.ToProductEntity();

            IFormFile Image = Request.Form.Files["image"];

            entity.Image = Image.FromStringToByteArray();

            if (Addons.Count > 0)
            {
                entity.AddOnProducts = Addons;
            }

            if (model.Variations.Small == null &&  model.Variations.Medium == null && model.Variations.Large == null && model.Variations.ExtraLarge == null)
            {
                entity.Variations = null;
            }

            ProductHandler.AddProduct(entity);
            return Redirect($"/Product/RestauranAdminProductList/{manager.Restaurant.Id}");

        }



    }
}
