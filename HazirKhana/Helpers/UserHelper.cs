using EntityLib.UserManagment;
using HazirKhana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Helpers
{
    public static class UserHelper
    {
        public static UserModel ToUserModel(this User entity)
        {
            UserModel model = new UserModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Address = entity.Address;
                model.Email = entity.Email;
                model.PasswordHash = entity.PasswordHash;
                model.PhoneNumber = entity.PhoneNumber;
                if(entity.Image != null)
                {
                    model.Image = Convert.ToBase64String(entity.Image);
                }
            }
            return model;
        }

        public static List<UserModel> ToUserList(this List<User> entities)
        {
            List<UserModel> modelList = new List<UserModel>();

            if (entities != null)
            {
                foreach (var User in entities)
                {
                    modelList.Add(User.ToUserModel());
                }     
            }

            return modelList;
        }

        public static User ToUserEntity(this UserModel model)
        {
            User entity = new User();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.Email = model.Email;
                entity.PasswordHash = model.PasswordHash;
                entity.PhoneNumber = model.PhoneNumber;
            }

            return entity;
        }

        public static List<User> ToRestaurantManagerList(this List<UserModel> modelList)
        {
            List<User> entityList = new List<User>();

            if (modelList != null)
            {
                foreach (var User in modelList)
                {
                    entityList.Add(User.ToUserEntity());
                }
            }

            return entityList;
        }

        public static RestaurantManagerModel ToRestaurantManagerModel(this RestaurantManager entity)
        {
            RestaurantManagerModel model = new RestaurantManagerModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Restaurant = entity.Restaurant.ToRestaurantModel();
                model.User = entity.User.ToUserModel();
            }

            return model;
        }

        public static RestaurantManager ToRestaurantManagerEntity(this RestaurantManagerModel model)
        {
            RestaurantManager entity = new RestaurantManager();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Restaurant = model.Restaurant.ToRestaurantEntity();
                entity.User = model.User.ToUserEntity();
            }

            return entity;
        }

        public static List<RestaurantManagerModel> ToRestaurantManagerList(this List<RestaurantManager> entites)
        {
            List<RestaurantManagerModel> modelList = new List<RestaurantManagerModel>();

            if (entites != null)
            {
                foreach (var RestaurantManager in entites)
                {
                    modelList.Add(RestaurantManager.ToRestaurantManagerModel());
                }
            }

            return modelList;
        }

    }
}
