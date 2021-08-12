using EntityLib.UserManagment;
using HazirKhana.Extras;
using HazirKhana.Helpers;
using HazirKhana.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HazirKhana.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(SignInManager<IdentityUser> singInmanager, UserManager<IdentityUser> userManager)
        {
            _signInManager = singInmanager;

            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent:false, lockoutOnFailure: false);

            
            if (result.Succeeded)
            {

                IdentityUser userSignin = await _userManager.FindByEmailAsync(model.Email);

                IList<string> roles = await _signInManager.UserManager.GetRolesAsync(userSignin);

                if(roles.Count > 0)
                {
                    if(roles[0] == Constants.Admin)
                    {
                        HttpContext.Session.Set(Constants.Key, userSignin);
                        return RedirectToAction("index", "AdminHome");
                    }
                    else if (roles[0] == Constants.RestauranAdmin)
                    {
                        RestaurantManagerModel manager = RestauranManagerHandler.GetRestaurantManager(userSignin.Id).ToRestaurantManagerModel();
                        HttpContext.Session.Set(Constants.Key, manager);
                        return RedirectToAction("index", "RestaurantAdmin");
                    }
                }


            }
            return View();
        }

    }
}
