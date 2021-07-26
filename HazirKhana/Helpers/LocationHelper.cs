using EntityLib.LocationManagment;
using HazirKhana.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class LocationHelper
    {
        public static CityModel ToCityModel(this City entity)
        {
            CityModel model = new CityModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.PostalCode = entity.PostalCode;
                if (entity.Provience != null)
                {
                    model.Provience = entity.Provience.ToProvienceModel();
                }
            }

            return model;

        }

        public static List<CityModel> ToCityModelList(this List<City> entities)
        {

            List<CityModel> modelList = new List<CityModel>();

            if (entities.Count > 0)
            {
                foreach (var city in entities)
                {
                    modelList.Add(city.ToCityModel());
                }
            }

            return modelList;
        }
        public static ProvienceModel ToProvienceModel(this Provience entity)
        {
            ProvienceModel model = new ProvienceModel();

            if(entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
            }

            return model;
        }

        public static List<ProvienceModel> ToProvienceModelList(this List<Provience> entites)
        {

            List<ProvienceModel> modelList = new List<ProvienceModel>();

            if (entites.Count > 0)
            {
                foreach (var provience in entites)
                {
                    modelList.Add(provience.ToProvienceModel());
                }
            }

            return modelList;
        }



        public static City ToCityEntity(this CityModel model)
        {
            City entity = new City();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.PostalCode = model.PostalCode;
                if (model.Provience != null)
                {
                    entity.Provience = model.Provience.ToProvieceEntity();
                }
            }

            return entity;
        }

        public static Provience ToProvieceEntity(this ProvienceModel model)
        {
            Provience entity = new Provience();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
            }
            return entity;
        }

        public static List<SelectListItem> ToCitySelectListItem(this List<City> entites)
        {
            List<SelectListItem> cities = new List<SelectListItem>();

            if (entites != null)
            {
                foreach (var city in entites)
                {
                    cities.Add(new SelectListItem { Text = city.Name, Value = Convert.ToString(city.Id) });
                }

            }

            return cities;
        }
        public static List<SelectListItem> ToProvienceSelectListItem(this List<Provience> entites)
        {
            List<SelectListItem> proviences = new List<SelectListItem>();

            if (entites != null)
            {
                foreach (var provience in entites)
                {
                    proviences.Add(new SelectListItem { Text = provience.Name, Value = Convert.ToString(provience.Id) });
                }

            }

            return proviences;
        }
    }
}
