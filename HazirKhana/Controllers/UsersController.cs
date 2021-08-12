using EntityLib.UserManagment;
using HazirKhana.Extras;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;

        public UsersController(UserManager<IdentityUser> UserManager)
        {
            _usermanager = UserManager;
        }

        public IActionResult Index()
        {
            List<UserModel> users = UserHandler.GetUsers().ToUserList();

            ViewData["Users"] = users;

            return View();
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            List<SelectListItem> Roles = new List<SelectListItem>();
            Roles.Add(new SelectListItem {  Text= Constants.Admin});
            Roles.Add(new SelectListItem { Text = Constants.Customer });
            Roles.Add(new SelectListItem { Text = Constants.RestauranAdmin});

            ViewData["Roles"] = Roles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel model)
        {


            User user = new User() { Name = model.Name, UserName = model.Email, Address = model.Address, Email = model.Email, PhoneNumber = model.PhoneNumber };
            IFormFile image = Request.Form.Files["image"];
            user.Image = image.FromStringToByteArray();

            var result = await _usermanager.CreateAsync(user,model.PasswordHash);
            if (result.Succeeded)
            {
                await _usermanager.AddToRoleAsync(user, Constants.Admin);
            }
            return RedirectToAction("index");
        }
    }
}
