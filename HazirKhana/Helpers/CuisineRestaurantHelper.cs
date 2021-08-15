using EntityLib.RestaurantManagment;
using HazirKhana.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class CuisineRestaurantHelper
    {
        public static CuisineRestaurant ToEntity(this CuisineRestaurantModel model)
        {

            CuisineRestaurant entity = new CuisineRestaurant();

            if (model  != null)
            {
                entity.CuisinesId = model.CuisinesId;
                entity.RestaurantsId = model.RestaurantsId;
                entity.Cuisines = model.Cuisines.ToCuisineEntity();
                entity.Restaurants = model.Restaurants.ToRestaurantEntity();
            }

            return entity;
        }

        public static CuisineRestaurantModel ToModel(this CuisineRestaurant entity)
        {

            CuisineRestaurantModel model = new CuisineRestaurantModel();

            if (entity != null)
            {
                model.CuisinesId = entity.CuisinesId;
                model.RestaurantsId = entity.RestaurantsId;
                if (entity.Cuisines !=null)
                {
                    model.Cuisines = entity.Cuisines.ToCuisineModel();
                }
                if (entity.Restaurants != null)
                {
                    model.Restaurants = entity.Restaurants.ToRestaurantModel();
                }

            }

            return model;
        }


        public static List<CuisineRestaurantModel> ToModelList(this List<CuisineRestaurant> entites)
        {
            List<CuisineRestaurantModel> modelList = new List<CuisineRestaurantModel>();

            foreach (var item in entites)
            {
                modelList.Add(item.ToModel());
            }

            return modelList;
        }


        public static List<CuisineRestaurant> ToEntitylList(this List<CuisineRestaurantModel> Modeles)
        {
            List<CuisineRestaurant> entityList = new List<CuisineRestaurant>();

            foreach (var item in Modeles)
            {
                entityList.Add(item.ToEntity());
            }

            return entityList;
        }
    }
}
