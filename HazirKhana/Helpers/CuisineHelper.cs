using EntityLib.CuisineManagment;
using HazirKhana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class CuisineHelper
    {
        public static CuisineModel ToCuisineModel(this Cuisine entity)
        {
            CuisineModel model = new CuisineModel();

            if (entity != null)
            {
                model.Id = entity.Id;

                model.Name = entity.Name;
                if (entity.Description != null)
                {
                    model.Description = entity.Description;
                }
                if (entity.Image != null)
                {
                    model.Image = Convert.ToBase64String(entity.Image);
                }

                model.State = entity.State;
            }

            return model;
        }

        public static Cuisine ToCuisineEntity(this CuisineModel model)
        {
            Cuisine entity = new Cuisine();

            if (model != null)
            {
                entity.Id = model.Id;

                entity.Name = model.Name;

                entity.Description = model.Description;

                entity.State = model.State;
            }

            return entity;
        }

        public static List<CuisineModel> ToCuisineModelList( this List<Cuisine> entities)
        {
            List<CuisineModel> modelList = new List<CuisineModel>();

            if (entities.Count > 0)
            {
                foreach (var cuisine in entities)
                {
                    modelList.Add(cuisine.ToCuisineModel());
                }
            }
            return modelList;
        }

        public static List<Cuisine> ToCuisineEntityList(this List<CuisineModel> models)
        {
            List<Cuisine> enitiyList = new List<Cuisine>();

            if (models.Count >0)
            {
                foreach (var cuisine in models)
                {
                    enitiyList.Add(cuisine.ToCuisineEntity());
                }
            }


            return enitiyList;

        }

    }
}
