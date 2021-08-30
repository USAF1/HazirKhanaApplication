using EntityLib.ProductsManagment;
using HazirKhana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class ProductHelper
    {
        public static ProductModel ToProductModel(this Product entity)
        {
            List<AddOnModel> addons = new List<AddOnModel>();
            ProductModel model = new ProductModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Price = entity.Price;
                model.Restaurant = entity.Restaurant.ToRestaurantModel();
                if (entity.Image != null)
                {
                    model.Image = Convert.ToBase64String(entity.Image);
                }
                
                model.Cuisine = entity.Cuisine.ToRestaurantCuisineModel();

                if (entity.Variations != null)
                {
                    model.Variations = entity.Variations.ToVariationModel();
                }
                if (entity.AddOnProducts != null)
                {
                    foreach (var item in entity.AddOnProducts) 
                    {
                        addons.Add(item.AddOns.ToModel());
                    }

                    model.AddOns = addons;
                }
                
            }

            return model;
        }

        public static Product ToProductEntity(this ProductModel model)
        {
            Product entity = new Product();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.Restaurant = model.Restaurant.ToRestaurantEntity();
                entity.Cuisine = model.Cuisine.ToRestaurantCuisineEntity();
                if (model.Variations != null)
                {
                    entity.Variations = model.Variations.ToVariationEntity();
                }
            }
            return entity;
        }

        public static List<ProductModel> ToProductModelList(this List<Product> entitie)
        {
            List<ProductModel> modelList = new List<ProductModel>();

            if (entitie != null)
            {
                foreach (var product in entitie)
                {
                    modelList.Add(product.ToProductModel());
                }
            }
            return modelList;
        }

        public static List<Product> ToProductEntity(this List<ProductModel> modelList)
        {
            List<Product> entityList = new List<Product>();

            if (modelList != null)
            {
                foreach (var product in modelList)
                {
                    entityList.Add(product.ToProductEntity());
                }

            }

            return entityList;

        }

    }
}
