using EntityLib.RestaurantCuisineManagment;
using HazirKhana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class RestaurantCuisineHelper
    {
        public static RestaurantCuisineModel ToRestaurantCuisineModel(this RestaurantCuisine entity)
        {
            RestaurantCuisineModel model = new RestaurantCuisineModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                if (model.Image != null)
                {
                    model.Image = Convert.ToBase64String(entity.Image);
                }
                model.Description = entity.Description;
                model.Restaurant = entity.Restaurant.ToRestaurantModel();
            }
            return model;

        }

        public static RestaurantCuisine ToRestaurantCuisineEntity(this RestaurantCuisineModel model)
        {
            RestaurantCuisine entity = new RestaurantCuisine();

            if (entity != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Restaurant = model.Restaurant.ToRestaurantEntity();

            }
            return entity;

        }

        public static List<RestaurantCuisineModel> ToRestaurantCuisineModelList(this List<RestaurantCuisine> entities)
        {

            List<RestaurantCuisineModel> modelList = new List<RestaurantCuisineModel>();
            if (entities !=null)
            {
                foreach (var entity in entities)
                {
                    modelList.Add(entity.ToRestaurantCuisineModel());
                }
            }
           
            return modelList;

        }


        public static List<RestaurantCuisine> ToRestaurantCuisineEntityList(this List<RestaurantCuisineModel> models)
        {

            List<RestaurantCuisine> entityList = new List<RestaurantCuisine>();
            if (models != null)
            {
                foreach (var model in models)
                {
                    entityList.Add(model.ToRestaurantCuisineEntity());
                }
            }

            return entityList;

        }

    }
}
