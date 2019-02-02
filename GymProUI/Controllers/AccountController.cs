using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPBOL;
using GymProUI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymProUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {



        UserManager<GPUser> userManager;
        SignInManager<GPUser> signInManager;

        public AccountController(UserManager<GPUser> _userManager, SignInManager<GPUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                GPUser user = new GPUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var resultCreate = await userManager.CreateAsync(user, model.Password);
                var resultRoleAssign = await userManager.AddToRoleAsync(user, "User");
                var resultSign = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
                if (resultSign.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //log in
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

                //now check the result
                if (Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }


        //Logout 

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}