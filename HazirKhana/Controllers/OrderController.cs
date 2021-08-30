using EntityLib.AddOnManagment;
using EntityLib.ProductsManagment;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult PlaceOrder(CartItemModel model)
        {
            Product entity = ProductHandler.GetPopUpProduct(model.Product.Id);

            List<AddOnModel> addOns = new List<AddOnModel>();

            if (model.Product.AddOns != null)
            {
                foreach (var item in model.Product.AddOns)
                {
                    if (item.IsSelected == true)
                    {
                        addOns.Add(item);
                        model.TotalPrice = model.TotalPrice + item.Price;
                    }
                }
            }

            if (model.Product.Variations != null)
            {

                if (model.Product.Variations.IsSelectedSmall == true)
                {
                    model.ProductVariation = new CartitemVariation() { Name = model.Product.Variations.Small, Price = model.Product.Variations.SmallPrice };
                    

                }
                else if (model.Product.Variations.IsSelectedMedium == true)
                {

                    model.ProductVariation = new CartitemVariation() { Name = model.Product.Variations.Medium, Price = model.Product.Variations.MediumPrice };
                
                }
                else if (model.Product.Variations.IsSelectedLarge == true)
                {
                    model.ProductVariation = new CartitemVariation() { Name = model.Product.Variations.Large, Price = model.Product.Variations.LargePrice };
                  
                }
                else if (model.Product.Variations.IsSelectedExtraLarge == true)
                {
                    model.ProductVariation = new CartitemVariation() { Name = model.Product.Variations.ExtraLarge, Price = model.Product.Variations.XlPrice };
                    
                }

            }


            model.Product.Name = entity.Name;
            model.Product.Cuisine = entity.Cuisine.ToRestaurantCuisineModel();
            model.Product.Discription = entity.Discription;
            model.Product.Restaurant = entity.Restaurant.ToRestaurantModel();
            model.ItemAddOns = addOns;
            model.Product.Price = entity.Price;

            if(model.Product.Variations != null)
            {
                model.TotalPrice = model.TotalPrice + (model.ProductVariation.Price * model.Quantity);
            }
            else
            {
                model.TotalPrice = model.TotalPrice + (model.Product.Price * model.Quantity);
            }


            

            return View(model);
        }
    }
}
