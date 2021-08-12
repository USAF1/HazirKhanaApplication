using EntityLib.AddOnManagment;
using HazirKhana.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace HazirKhana.Helpers
{
    public static class AddOnHelper
    {

        public static AddOnModel ToModel(this AddOn entity)
        {
            AddOnModel model = new AddOnModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Price = entity.Price;
                model.Restaurant = entity.Restaurant.ToRestaurantModel();
            }

            return model;
        }

        public static AddOn ToEntity(this AddOnModel model)
        {
            AddOn entity = new AddOn();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Restaurant = model.Restaurant.ToRestaurantEntity();
            }

            return entity;
        }

        public static List<AddOnModel> ToModelList(this List<AddOn>entityList)
        {
            List<AddOnModel> modelList = new List<AddOnModel>();

            if (entityList != null)
            {
                foreach (var addon in entityList)
                {
                    modelList.Add(addon.ToModel());
                }
            }
            return modelList;
        }

        public static List<SelectListItem> ToSelectListItems(this List<AddOn> entityList)
        {
            List<SelectListItem> itemList = new List<SelectListItem>();

            if (entityList != null)
            {
                foreach (var item in entityList)
                {
                    itemList.Add(new SelectListItem { Text = item.Name, Value = Convert.ToString(item.Id)});
                }
    
            }
            return itemList;

        }
    }
}
