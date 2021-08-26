using HazirKhana.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Extras
{
    public static class ExtrasHandler
    {

        public static List<SelectListItem> OptionsSelectListItem()
        {
            List<SelectListItem> options = new List<SelectListItem>();

            options.Add(new SelectListItem { Text = "True"});
            options.Add(new SelectListItem { Text = "False"});

            return options;
        }

        public static byte[] FromStringToByteArray(this IFormFile photo)
        {

            if (photo != null && photo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null;

        }



        public static void Set<T>(this ISession session, string key, T obj)
        {
            session.SetString(key, JsonConvert.SerializeObject(obj));
        }


        public static T Get<T>(this ISession session, string key)
        {
            string data = session.GetString(key);

            if (string.IsNullOrWhiteSpace(data)) return default;

            return JsonConvert.DeserializeObject<T>(data);
        }



        public static List<SelectListItem> StateSelectListItem()
        {
            List<SelectListItem> options = new List<SelectListItem>();

            options.Add(new SelectListItem { Text = Constants.ActiveStatus });
            options.Add(new SelectListItem { Text = Constants.DeleteStatus });

            return options;
        }


    }
}
