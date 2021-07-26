using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhanaWEB.Extras
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

    }
}
