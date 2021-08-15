using EntityLib.ProductsManagment;
using HazirKhana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class ProductVariationHepler
    {

        public static ProductVariationModel ToVariationModel(this ProductVaration entity)
        {
            ProductVariationModel model = new ProductVariationModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Small = entity.Small;
                model.SmallPrice = entity.SmallPrice;
                model.Medium = entity.Medium;
                model.MediumPrice = entity.MediumPrice;
                model.Large = entity.Large;
                model.LargePrice = entity.LargePrice;
                model.ExtraLarge = entity.ExtraLarge;
                model.XlPrice = entity.XlPrice;
            }


            return model;
        }


        public static List<ProductVariationModel> ToVariationModelList(this List<ProductVaration> entitylist)
        {
            List<ProductVariationModel> modelList = new List<ProductVariationModel>();

            if (entitylist != null)
            {
                foreach (var item in entitylist)
                {
                    modelList.Add(item.ToVariationModel());
                }
            }
            return modelList;
        }


        public static ProductVaration ToVariationEntity(this ProductVariationModel model)
        {
            ProductVaration entity = new ProductVaration();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Small = model.Small;
                entity.SmallPrice = model.SmallPrice;
                entity.Medium = model.Medium;
                entity.MediumPrice = model.MediumPrice;
                entity.Large = model.Large;
                entity.LargePrice = model.LargePrice;
                entity.ExtraLarge = model.ExtraLarge;
                entity.XlPrice = model.XlPrice;
            }


            return entity;
        }


        public static List<ProductVaration> ToVariationEntityList(this List<ProductVariationModel> modelList)
        {
            List<ProductVaration> entityList = new List<ProductVaration>();

            if (modelList != null)
            {
                foreach (var item in modelList)
                {
                    entityList.Add(item.ToVariationEntity());
                }
            }
            return entityList;
        }
    }
}
